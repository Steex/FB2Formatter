using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Web;
using System.Globalization;
using System.Windows.Forms;


namespace FB2Formatter
{
	public class BookFormatter
	{
		private enum TextFormatMode
		{
			Structured,
			Inline,
			Preformatted,
		}

		private enum BookBodyType
		{
			None,
			Main,
			Notes,
			Comments,
			Unknown,
		}

		// Footnote or comment info.
		private class ReferenceInfo
		{
			// Link to the ref's content (attribute "l:href").
			public string Href { get; set; }
			// Link to the ref's type (usually "note" or "comment"; attribute "type").
			public string Type { get; set; }
			// Text of the reference inside the main text (usually something like "[1]").
			public string Text { get; set; }
		}

		private class BookNodeInfo
		{
			// Name of node tag without angle brackets. Example: "section"
			public string Name { get; set; }
			// Text processing mode at the current node and the default mode for all its subnodes.
			public TextFormatMode FormatMode { get; set; }
			// True if the node does not contain another nodes.
			public bool Empty { get; set; }

			public BookNodeInfo(string name, TextFormatMode formatMode)
			{
				Name = name;
				FormatMode = formatMode;
				Empty = true;
			}
		}

		private class BookNodeStack
		{
			private static readonly HashSet<String> inlineTextTags = new HashSet<String> {
				/*formatted text*/ "p", "v", "subtitle", "text-author", "th", "td",
				/*author*/         "first-name", "middle-name", "last-name", "nickname", "home-page", "email",
				/*title-info*/     "genre", "id", "book-title", "lang", "src-lang", "keywords", "date",
				/*document-info*/  "src-url", "src-ocr", "version", "program-used",
				/*publish-info*/   "book-name", "publisher", "city", "year", "isbn",
				/*custom-info*/    "custom-info"
			};

			private static readonly HashSet<String> preformattedTextTags = new HashSet<String> { "code" };

			private TextFormatMode defaultFormatMode;
			private Stack<BookNodeInfo> items;

			public int Count
			{
				get
				{
					return items.Count;
				}
			}

			public string NodeName
			{
				get
				{
					return items.Count > 0 ? items.Peek().Name : null;
				}
			}

			public bool NodeEmpty
			{
				get
				{
					return items.Count > 0 ? items.Peek().Empty : true;
				}
			}

			public TextFormatMode FormatMode
			{
				get
				{
					return items.Count > 0 ? items.Peek().FormatMode : defaultFormatMode;
				}
			}


			public BookNodeStack(TextFormatMode defaultFormatMode)
			{
				this.defaultFormatMode = defaultFormatMode;
				items = new Stack<BookNodeInfo>();
			}

			public void AddNode(string name)
			{
				// The current item is not empty anymore.
				if (items.Any())
				{
					items.Peek().Empty = false;
				}

				// Determine the format mode.
				TextFormatMode formatMode;
				if (inlineTextTags.Contains(name))
				{
					formatMode = TextFormatMode.Inline;
				}
				else if (preformattedTextTags.Contains(name))
				{
					formatMode = TextFormatMode.Preformatted;
				}
				else
				{
					formatMode = TextFormatMode.Structured;
				}

				// Inner items cannot make the format mode more strict.
				if (formatMode < FormatMode)
				{
					formatMode = FormatMode;
				}

				// Add the new item.
				items.Push(new BookNodeInfo(name, formatMode));
			}

			public void DeleteNode(string name)
			{
				// Make sure the stack is not empty.
				if (!items.Any())
				{
					throw new Exception("Node stack is empty.");
				}

				// Make sure the opening and the closing tags correspond.
				if (items.Peek().Name != name)
				{
					throw new Exception(string.Format("Book node hierarchy is broken: open node: \"{0}\", closing node \"{1}\".", items.Peek().Name, name));
				}

				// Remove the item.
				items.Pop();
			}
		}

		private class EncodingData
		{
			private HashSet<char> validChars;

			public Encoding Encoding { get; private set; }
			public bool Enforced { get; set; }

			public EncodingData(Encoding encoding)
			{
				Encoding = encoding;

				if (encoding.IsSingleByte)
				{
					validChars = new HashSet<char>();
					byte[] charCodes = Enumerable.Range(1, 255).Select(n=>(byte)n).ToArray();
					foreach (char chr in encoding.GetChars(charCodes))
					{
						validChars.Add(chr);
					}
				}
			}

			public bool CanRepresentChar(char chr)
			{
				return validChars == null || validChars.Contains(chr);
			}
		}


		private static readonly string msgEncodingInsufficient =
			"\"{0}\"" + Environment.NewLine +
			Environment.NewLine +
			"The book contains symbols which cannot be represent with the source encoding \"{1}\"." + Environment.NewLine +
			"Encoding will be changed to UTF-8." + Environment.NewLine +
			"Select \"No\" to escape such symbols instead.";

		private static readonly string errXmlParseError =
			"\"{0}\"" + Environment.NewLine +
			"XML error at line {1}, char {2}:" + Environment.NewLine +
			"{3}";

		private static readonly string errRefWithoutHref =
			"\"{0}\"" + Environment.NewLine +
			"A reference without a href is found." + Environment.NewLine +
			"Notes/comments in the book cannot be formatted.";

		private static readonly string errRefNotLocal =
			"\"{0}\"" + Environment.NewLine +
			"A reference that is not local is found." + Environment.NewLine +
			"Notes/comments in the book cannot be formatted.";


		private static readonly string formatNoteName = "[{0}]";
		private static readonly string formatCommentName = "{{{1}}}";

		private string sourceFileName;
		private string targetFileName;

		private string sourceEncodingName = null;
		private EncodingData targetEncoding = new EncodingData(Encoding.UTF8);
		private StringBuilder output = new StringBuilder();

		private BookBodyType bodyType;
		private int bodyNumber;
		private Dictionary<string, ReferenceInfo> references;
		private ReferenceInfo currentReference;
		private int currentReferenceTextStart;
		private int nextNoteNumber = 1;
		private int nextCommentNumber = 1;


		public BookFormatter(string sourceFile, string targetFile)
		{
			sourceFileName = sourceFile;
			targetFileName = targetFile;
		}

		public void FormatBook()
		{
			if (Config.Main.FormatNotes || Config.Main.FormatComments)
			{
				CollectReferences();
			}

			ProcessSourceBook();
			WriteTargetBook();
		}


		private void CollectReferences()
		{
			references = new Dictionary<string, ReferenceInfo>();

			XmlDocument book = BookUtils.OpenBook(sourceFileName);

			bodyType = BookBodyType.None;
			bodyNumber = 0;
			CollectReferences_ProcessElement(book.DocumentElement);
		}

		private void CollectReferences_ProcessElement(XmlElement element)
		{
			foreach (XmlElement child in element.ChildNodes.OfType<XmlElement>())
			{
				// Process the child.
				switch (child.Name)
				{
					case "body":
						CollectReferences_ProcessBody(child); 
						break;
					case "a":
						CollectReferences_ProcessAnchor(child);
						break;
					case "section":
						CollectReferences_ProcessSection(child);
						break;
				}

				// Recursive process child's subnodes.
				CollectReferences_ProcessElement(child);
			}
		}

		private void CollectReferences_ProcessBody(XmlElement element)
		{
			bodyNumber += 1;

			switch (element.GetAttribute("type"))
			{
				case "":
					bodyType = (bodyNumber == 1) ? BookBodyType.Main : BookBodyType.Comments;
					break;
				case "notes":
					bodyType = BookBodyType.Notes;
					break;
				case "comments":
					bodyType = BookBodyType.Comments;
					break;
				default:
					bodyType = BookBodyType.Unknown;
					break;
			}
		}

		private void CollectReferences_ProcessAnchor(XmlElement element)
		{
			if (bodyType == BookBodyType.Main)
			{
				// Collect a ref info.
				ReferenceInfo refInfo = new ReferenceInfo();
				refInfo.Href = element.GetAttribute("l:href");
				refInfo.Type = element.GetAttribute("type");

				// Make sure the href is set.
				if (string.IsNullOrWhiteSpace(refInfo.Href))
				{
					throw new Exception(string.Format(errRefWithoutHref, sourceFileName));
				}

				// Make sure the href is local.
				if (refInfo.Href[0] != '#')
				{
					throw new Exception(string.Format(errRefNotLocal, sourceFileName));
				}

				// Remove '#' at the href's start.
				refInfo.Href = refInfo.Href.Remove(0, 1);

				// Remember the reference.
				references.Add(refInfo.Href, refInfo);
			}
		}

		private void CollectReferences_ProcessSection(XmlElement element)
		{
			// Add an implicit "comment" mark to all comment references.
			if (bodyType == BookBodyType.Comments)
			{
				string sectionId = element.GetAttribute("id");
				if (!string.IsNullOrWhiteSpace(sectionId))
				{
					ReferenceInfo refInfo = null;
					references.TryGetValue(sectionId, out refInfo);
					if (refInfo != null && string.IsNullOrEmpty(refInfo.Type))
					{
						refInfo.Type = "comment";
					}
				}
			}
		}


		private void ProcessSourceBook()
		{
			BookNodeStack nodeStack = new BookNodeStack(TextFormatMode.Structured);
			bool allowWhitespace = false;
			bool wordBegin = true;
			bool binaryElement = false;

			// Read the source book and write formatted content into a buffer.
			using (XmlTextReader reader = new XmlTextReader(sourceFileName))
			{
				try
				{
					while (reader.Read())
					{
						switch (reader.NodeType)
						{
							case XmlNodeType.XmlDeclaration:
								sourceEncodingName = reader["encoding"];
								targetEncoding = new EncodingData(Encoding.GetEncoding(sourceEncodingName));
								break;

							case XmlNodeType.Element:
								string elementName = reader.Name;
								bool elementEmpty = reader.IsEmptyElement;

								WriteElementOpeningTag(elementName, nodeStack.FormatMode, nodeStack.Count);

								while (reader.MoveToNextAttribute())
								{
									WriteElementAttribute(reader.Name, reader.Value);

									if (!elementEmpty &&
										references != null &&
										elementName == "a" && reader.Name == "l:href")
									{
										currentReference = FindReference(reader.Value);
									}
								}

								if (elementEmpty)
								{
									WriteEmptyElementCloser();
								}
								else
								{
									WriteElementCloser();
								}

								if (currentReference != null)
								{
									currentReferenceTextStart = output.Length;
								}

								allowWhitespace = allowWhitespace && nodeStack.FormatMode != TextFormatMode.Structured;
								wordBegin = wordBegin || nodeStack.FormatMode != TextFormatMode.Inline;

								if (!elementEmpty)
								{
									nodeStack.AddNode(elementName);
								}

								binaryElement = (elementName == "binary" && !elementEmpty);
								break;

							case XmlNodeType.EndElement:
								TextFormatMode insideFormatMode = nodeStack.FormatMode;
								nodeStack.DeleteNode(reader.Name);
								TextFormatMode outsideFormatMode = nodeStack.FormatMode;

								if (insideFormatMode == TextFormatMode.Inline &&
									outsideFormatMode == TextFormatMode.Structured)
								{
									DeleteTrailingWhitespace();
								}

								if (reader.Name == "a" && currentReference != null)
								{
									SetReferenceName(currentReference, output.ToString(currentReferenceTextStart, output.Length - currentReferenceTextStart));
									currentReference = null;
								}

								WriteElementClosingTag(reader.Name, insideFormatMode, nodeStack.Count);

								allowWhitespace = allowWhitespace && nodeStack.FormatMode != TextFormatMode.Structured;
								wordBegin = wordBegin || nodeStack.FormatMode != TextFormatMode.Inline;
								binaryElement = false;
								break;

							case XmlNodeType.Whitespace:
							case XmlNodeType.SignificantWhitespace:
								if (nodeStack.FormatMode != TextFormatMode.Structured)
								{
									WriteText(reader.Value, nodeStack.FormatMode, ref allowWhitespace, ref wordBegin);
								}
								break;

							case XmlNodeType.Text:
								if (binaryElement)
								{
									WriteBinary(reader.Value, nodeStack.Count);
								}
								else
								{
									WriteText(reader.Value, nodeStack.FormatMode, ref allowWhitespace, ref wordBegin);
								}
								break;

							case XmlNodeType.Comment:
								WriteComment(reader.Value, nodeStack.FormatMode, nodeStack.Count);
								allowWhitespace = true;
								wordBegin = true;
								break;
						}
					}
				}
				catch (Exception ex)
				{
					string message = string.Format(errXmlParseError, sourceFileName, reader.LineNumber, reader.LinePosition, ex.Message);
					throw new Exception(message, ex);
				}
			}
		}

		private void WriteTargetBook()
		{
			// Write the converted book content into a file.
			using (StreamWriter targetWriter = new StreamWriter(targetFileName, false, targetEncoding.Encoding))
			{
				// Determine the output encoding name. If the source encoding is not changed,
				// write the encoding exactly as it was taken from the source file.
				string encodingName;
				if (!string.IsNullOrWhiteSpace(sourceEncodingName) &&
					targetEncoding.Encoding == Encoding.GetEncoding(sourceEncodingName))
				{
					encodingName = sourceEncodingName;
				}
				else
				{
					encodingName = targetEncoding.Encoding.WebName;
				}

				// Write the file header.
				targetWriter.Write(string.Format("<?xml version=\"1.0\" encoding=\"{0}\"?>", encodingName));

				// Write the book content.
				targetWriter.Write(output.ToString());
			}
		}


		private void WriteElementOpeningTag(string name, TextFormatMode formatMode, int level)
		{
			if (formatMode == TextFormatMode.Structured)
			{
				output.AppendLine();
				WriteLineIndent(level);
			}

			output.AppendFormat("<{0}", name);
		}

		private void WriteElementClosingTag(string name, TextFormatMode formatMode, int level)
		{
			if (formatMode == TextFormatMode.Structured)
			{
				output.AppendLine();
				WriteLineIndent(level);
			}

			output.AppendFormat("</{0}>", name);
		}

		private void WriteEmptyElementCloser()
		{
			output.Append("/>");
		}

		private void WriteElementCloser()
		{
			output.Append(">");
		}

		private void WriteElementAttribute(string name, string value)
		{
			output.Append(' ');
			output.Append(name);
			output.Append('=');
			output.Append('"');
			WriteXmlString(value, true);
			output.Append('"');
		}

		private void WriteText(string text, TextFormatMode formatMode, ref bool allowWhitespace, ref bool wordBegin)
		{
			switch (formatMode)
			{
				case TextFormatMode.Structured:
					throw new Exception("Unexpected text in the current context.");

				case TextFormatMode.Inline:
					WriteInlineText(text, ref allowWhitespace, ref wordBegin);
					break;

				case TextFormatMode.Preformatted:
					WriteXmlString(text, false);
					allowWhitespace = true;
					wordBegin = true;
					break;
			}
		}

		private void WriteInlineText(string text, ref bool allowWhitespace, ref bool wordBegin)
		{
			foreach (char chr in text)
			{
				UnicodeCategory charCategory = char.GetUnicodeCategory(chr);

				// Replace all simple whitespaces, tab symbols, and line/paragraph separators with single whitespace.
				// Other symbols (including special whitespaces) are written as is.
				bool isWhitespace =
					chr == ' ' ||
					chr == '\t' ||
					chr == '\r' ||
					chr == '\n' ||
					charCategory == UnicodeCategory.LineSeparator ||
					charCategory == UnicodeCategory.ParagraphSeparator;

				// Skip control symbols (except tab character, which will be replaced with the whitespace).
				if (!isWhitespace &&
					charCategory == UnicodeCategory.Control)
				{
					continue;
				}

				// Write the resolved symbol.
				if (chr == '"' && Config.Main.FormatQuotationMarks)
				{
					WriteXmlChar(wordBegin ? '«' : '»', false);
				}
				else if (!isWhitespace)
				{
					WriteXmlChar(chr, false);
				}
				else if (allowWhitespace)
				{
					output.Append(' ');
				}

				// Prepare to the next symbol.
				allowWhitespace = !isWhitespace;

				wordBegin =
					isWhitespace ||
					charCategory == UnicodeCategory.SpaceSeparator ||
					chr == '(' ||
					chr == '[' ||
					chr == '-';
			}
		}

		private void WriteBinary(string content, int level)
		{
			byte[] binaryContent = Convert.FromBase64String(content);
			foreach (string chunk in Utils.SplitStringBy(Convert.ToBase64String(binaryContent), Config.Main.BinaryLineSize))
			{
				output.AppendLine();
				WriteLineIndent(level);
				output.Append(chunk);
			}
		}

		private void DeleteTrailingWhitespace()
		{
			if (output.Length > 0 && output[output.Length - 1] == ' ')
			{
				output.Length -= 1;
			}
		}

		private void WriteComment(string content, TextFormatMode formatMode, int level)
		{
			if (formatMode == TextFormatMode.Structured)
			{
				output.AppendLine();
				WriteLineIndent(level);
			}

			output.Append("<!--");
			output.Append(content);
			output.Append("-->");
		}


		private void WriteXmlString(string str, bool escapeQuotes)
		{
			foreach (char chr in str)
			{
				WriteXmlChar(chr, escapeQuotes);
			}
		}

		private void WriteXmlChar(char chr, bool escapeQuotes)
		{
			switch (chr)
			{
				case '\'':
					output.Append('\''); // NOTE: do not escape single quotes
					break;
				case '"':
					output.Append(escapeQuotes ? "&qout;" : "\"");
					break;
				case '&':
					output.Append("&amp;");
					break;
				case '<':
					output.Append("&lt;");
					break;
				case '>':
					output.Append("&gt;");
					break;
				default:
					if (targetEncoding.CanRepresentChar(chr))
					{
						output.Append(chr);
					}
					else if (targetEncoding.Enforced)
					{
						output.AppendFormat("&#{0};", (int)chr);
					}
					else if (MessageBox.Show(string.Format(msgEncodingInsufficient, sourceFileName, sourceEncodingName), 
						"FBF", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
					{
						targetEncoding.Enforced = true;
						output.AppendFormat("&#{0};", (int)chr);
					}
					else
					{
						targetEncoding = new EncodingData(Encoding.UTF8);
						targetEncoding.Enforced = true;
						output.Append(chr);
					}
					break;
			}
		}

		private void WriteLineIndent(int level)
		{
			output.Append(new string(Config.Main.IndentChar, Config.Main.IndentSize * level));
		}


		private ReferenceInfo FindReference(string href)
		{
			// Empty hrefs are not allowed.
			if (string.IsNullOrWhiteSpace(href))
			{
				return null;
			}

			// Remove the local link prefix.
			if (href[0] == '#')
			{
				href = href.Remove(0, 1);
			}

			// Find the info.
			ReferenceInfo refInfo = null;
			references.TryGetValue(href, out refInfo);
			return refInfo;
		}

		private void SetReferenceName(ReferenceInfo refInfo, string defaultName)
		{
			if (refInfo.Type == "note" && Config.Main.RenumberNotes)
			{
				refInfo.Text = string.Format(formatNoteName, nextNoteNumber);
				nextNoteNumber += 1;
			}
			else if (refInfo.Type == "comment" && Config.Main.RenumberComments)
			{
				refInfo.Text = string.Format(formatCommentName, nextCommentNumber);
				nextCommentNumber += 1;
			}
			else
			{
				refInfo.Text = defaultName;
			}
		}
	}
}
