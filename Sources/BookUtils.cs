using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Web;
using System.Globalization;


namespace FB2Formatter
{
	public static class BookUtils
	{
		private enum TextFormatMode
		{
			Structured,
			Inline,
			Preformatted,
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
				/*title-info*/     "genre", "id", "book-title", "lang", "keywords", "date",
				/*document-info*/  "src-url", "src-ocr", "version", "program-used",
				/*publish-info*/   "book-name", "publisher", "city", "year", "isbn",
				/*custom-info*/    "custom-info"
			};

			private static readonly HashSet<String> preformattedTextTags = new HashSet<String> { "code" };

			private TextFormatMode defaultFormatMode;
			private Stack<BookNodeInfo> items;

			public int NodeLevel
			{
				get
				{
					return items.Count - 1;
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


		private class BinaryElementInfo
		{
			// The first line of the element.
			public int StartLine { get; set; }
			// Position of the first symbol.
			public int StartOffset { get; set; }
			// The last line of the element.
			public int EndLine { get; set; }
			// Position _after_ the last symbol.
			public int EndOffset { get; set; }
			public string Name { get; set; }
			public string Format { get; set; }
			public byte[] Content { get; set; }
		}


		private static readonly char indentSymbol = ' ';
		private static readonly int indentLength = 1;


		public static XmlDocument OpenBook(string path)
		{
			XmlDocument book = new XmlDocument();
			book.Load(path);
			return book;
		}

		public static IEnumerable<BookAttachment> EnumBookPictures(XmlDocument book)
		{
			foreach (XmlElement binary in book.DocumentElement.ChildNodes.OfType<XmlElement>().Where(e => e.Name == "binary"))
			{
				string contentType = binary.GetAttribute("content-type");
				if (contentType == "image/png" ||
					contentType == "image/jpeg")
				{
					yield return new BookAttachment(binary);
				}
			}
		}

		public static IEnumerable<BookAttachment> EnumFolderPictures(string folderPath)
		{
			foreach (string filePath in Directory.GetFiles(folderPath).OrderBy(n => n))
			{
				string extension = Path.GetExtension(filePath);
				if (extension == ".png" ||
					extension == ".jpg" ||
					extension == ".jpeg")
				{
					yield return new BookAttachment(filePath);
				}
			}
		}


		public static void FormatBook(string sourceFile, string targetFile)
		{
			BookNodeStack nodeStack = new BookNodeStack(TextFormatMode.Structured);
			Encoding encoding = Encoding.UTF8;
			StringBuilder output = new StringBuilder();

			try
			{
				using (XmlTextReader reader = new XmlTextReader(sourceFile))
				{
					while (reader.Read())
					{
						//output.AppendLine(String.Format("{}", ))
						switch (reader.NodeType)
						{
							case XmlNodeType.XmlDeclaration:
								encoding = Encoding.GetEncoding(reader["encoding"]);
								FormatBook_WriteDeclaration(output, reader.Value);
								break;

							case XmlNodeType.Element:
								string elementName = reader.Name;
								bool elementEmpty = reader.IsEmptyElement;

								FormatBook_WriteElementOpeningTag(output, elementName, nodeStack.FormatMode, nodeStack.NodeLevel + 1);
								FormatBook_WriteElementAttributes(output, reader);

								if (elementEmpty)
								{
									FormatBook_WriteEmptyElementCloser(output);
								}
								else
								{
									FormatBook_WriteElementCloser(output);
								}

								if (!elementEmpty)
								{
									nodeStack.AddNode(elementName);
								}
								break;

							case XmlNodeType.EndElement:
								FormatBook_WriteElementClosingTag(output, reader.Name, nodeStack.FormatMode, nodeStack.NodeLevel);
								nodeStack.DeleteNode(reader.Name);
								break;

							case XmlNodeType.Text:
								FormatBook_WriteText(output, reader.Value, nodeStack.FormatMode);
								break;
						}
					}
				}
			}
			catch (Exception ex)
			{
			}

			//
			File.WriteAllText(targetFile + ".txt", output.ToString(), encoding);
		}

		private static void FormatBook_WriteDeclaration(StringBuilder output, string content)
		{
			output.AppendFormat("<?xml {0}?>", content);
		}

		private static void FormatBook_WriteElementOpeningTag(StringBuilder output, string name, TextFormatMode formatMode, int level)
		{
			if (formatMode == TextFormatMode.Structured)
			{
				output.AppendLine();
				output.Append(new string(indentSymbol, indentLength * level));
			}

			output.AppendFormat("<{0}", name);
		}

		private static void FormatBook_WriteElementClosingTag(StringBuilder output, string name, TextFormatMode formatMode, int level)
		{
			if (formatMode == TextFormatMode.Structured)
			{
				output.AppendLine();
				output.Append(new string(indentSymbol, indentLength * level));
			}

			output.AppendFormat("</{0}>", name);
		}

		private static void FormatBook_WriteEmptyElementCloser(StringBuilder output)
		{
			output.Append("/>");
		}

		private static void FormatBook_WriteElementCloser(StringBuilder output)
		{
			output.Append(">");
		}

		private static void FormatBook_WriteElementAttributes(StringBuilder output, XmlTextReader reader)
		{
			while (reader.MoveToNextAttribute())
			{
				output.AppendFormat(" {0}=\"{1}\"", reader.Name, HttpUtility.HtmlEncode(reader.Value));
			}
		}

		private static void FormatBook_WriteText(StringBuilder output, string text, TextFormatMode formatMode)
		{
			switch (formatMode)
			{
				case TextFormatMode.Structured:
					throw new Exception("Cannot write text in the current context.");

				case TextFormatMode.Inline:
					output.Append(text);
					break;

				case TextFormatMode.Preformatted:
					output.Append(text);
					break;
			}
		}

		private static void FormatBook_WriteInlineText(StringBuilder output, string text)
		{
			bool allowWhitespace = true;
			foreach (char chr in text)
			{
				UnicodeCategory charCategory = char.GetUnicodeCategory(chr);

				// Skip control symbols
				if (charCategory == UnicodeCategory.Control)
				{
					continue;
				}

				// Replace all simple whitespaces and line separators with single whitespace.
				// Other symbols (including special whitespaces) are written as is.
				bool isWhitespace = 
					chr == ' ' ||
					charCategory == UnicodeCategory.LineSeparator;

				if (!isWhitespace)
				{
					output.Append(chr);
					allowWhitespace = true;
				}
				else if (allowWhitespace)
				{
					output.Append(' ');
					allowWhitespace = false;
				}
			}
		}



		public static void FormatBookPictures(string sourceFile, string targetFile)
		{
			// Collect binary items and determine encoding.
			Encoding encoding = null;
			List<BinaryElementInfo> binaries = new List<BinaryElementInfo>();
			BinaryElementInfo currentBinary = null;

			using (XmlTextReader reader = new XmlTextReader(sourceFile))
			{
				while (reader.Read())
				{
					switch (reader.NodeType)
					{
						case XmlNodeType.XmlDeclaration:
							encoding = Encoding.GetEncoding(reader["encoding"]);
							break;
						case XmlNodeType.Element:
							if (reader.Name == "binary")
							{
								currentBinary = new BinaryElementInfo();
								currentBinary.StartLine = reader.LineNumber - 1;
								currentBinary.StartOffset = reader.LinePosition - 1 - 1; // consider starting "<" symbol
								currentBinary.Name = reader["id"];
								currentBinary.Format = reader["content-type"];
							}
							break;
						case XmlNodeType.EndElement:
							if (reader.Name == "binary")
							{
								currentBinary.EndLine = reader.LineNumber - 1;
								currentBinary.EndOffset = reader.LinePosition + 7 - 1; // consider "binary>" symbols after "</" sequence
								binaries.Add(currentBinary);
							}
							break;
						case XmlNodeType.Text:
							if (currentBinary != null)
							{
								currentBinary.Content = Convert.FromBase64String(reader.Value);
							}
							break;
					}
				}
			}

			// Read the book as a text file and replace binary content.
			string[] lines = File.ReadAllLines(sourceFile, encoding);

			using (StreamWriter writer = new StreamWriter(targetFile, false, encoding))
			{
				int currentLine = 0;
				int currentChar = 0;

				foreach (BinaryElementInfo binary in binaries)
				{
					// Write all preceding lines
					while (currentLine < binary.StartLine)
					{
						if (currentChar > 0)
						{
							string remainder = lines[currentLine].Substring(currentChar);
							if (!string.IsNullOrWhiteSpace(remainder))
							{
								writer.WriteLine(remainder.Trim());
							}
						}
						else
						{
							writer.WriteLine(lines[currentLine]);
						}

						++currentLine;
						currentChar = 0;
					}

					// Write significant preceding characters.
					if (binary.StartOffset > currentChar)
					{
						string inclusion = lines[currentLine].Substring(currentChar, binary.StartOffset - currentChar);
						if (!string.IsNullOrWhiteSpace(inclusion))
						{
							writer.WriteLine(inclusion.TrimEnd());
						}
					}

					// Write binary element
					writer.WriteLine(" <binary id=\"{1}\" content-type=\"{0}\">", binary.Format, binary.Name);
					foreach (string chunk in SplitStringBy(Convert.ToBase64String(binary.Content), 80))
					{
						writer.WriteLine("  " + chunk);
					}
					writer.WriteLine(" </binary>");

					currentLine = binary.EndLine;
					currentChar = binary.EndOffset;
				}

				// Write the possible line remainder.
				if (currentChar > 0)
				{
					string remainder = lines[currentLine].Substring(currentChar);
					if (!string.IsNullOrWhiteSpace(remainder))
					{
						writer.WriteLine(remainder.TrimStart());
					}

					++currentLine;
					currentChar = 0;
				}

				// Write the remaining lines.
				while (currentLine < lines.Length)
				{
					writer.WriteLine(lines[currentLine]);
					++currentLine;
				}
			}
		}

		public static void ExtractPicturesToFiles(string sourceFile, string targetFolder)
		{
			XmlDocument book = OpenBook(sourceFile);

			Directory.CreateDirectory(targetFolder);

			foreach (BookAttachment picture in EnumBookPictures(book))
			{
				File.WriteAllBytes(Path.Combine(targetFolder, picture.FileName), picture.Content);
			}
		}

		public static void ExtractPicturesToXml(string sourceFile, string targetFile)
		{
			XmlDocument book = OpenBook(sourceFile);

			Encoding encoding = Encoding.GetEncoding((book.FirstChild as XmlDeclaration).Encoding);
			using (StreamWriter wr = new StreamWriter(targetFile, false, encoding))
			{
				foreach (BookAttachment picture in EnumBookPictures(book))
				{
					wr.WriteLine(" <binary id=\"{1}\" content-type=\"{0}\">", picture.Format, picture.Name);

					foreach (string chunk in SplitStringBy(Convert.ToBase64String(picture.Content), 80))
					{
						wr.WriteLine("  " + chunk);
					}

					wr.WriteLine(" </binary>");
				}
			}
		}

		public static void ConvertFolderPicturesToXml(string sourceFolder, string targetFile)
		{
			using (StreamWriter wr = new StreamWriter(targetFile, false, Encoding.ASCII))
			{
				foreach (BookAttachment picture in EnumFolderPictures(sourceFolder))
				{
					wr.WriteLine(" <binary id=\"{1}\" content-type=\"{0}\">", picture.Format, picture.Name);

					foreach (string chunk in SplitStringBy(Convert.ToBase64String(picture.Content), 80))
					{
						wr.WriteLine("  " + chunk);
					}

					wr.WriteLine(" </binary>");
				}
			}
		}

		public static void ConvertListPicturesToXml(IEnumerable<string> sourceFiles, string targetFile)
		{
			using (StreamWriter wr = new StreamWriter(targetFile, false, Encoding.ASCII))
			{
				foreach (string file in sourceFiles)
				{
					BookAttachment picture = new BookAttachment(file);

					wr.WriteLine(" <binary id=\"{1}\" content-type=\"{0}\">", picture.Format, picture.Name);

					foreach (string chunk in SplitStringBy(Convert.ToBase64String(picture.Content), 80))
					{
						wr.WriteLine("  " + chunk);
					}

					wr.WriteLine(" </binary>");
				}
			}
		}


		private static IEnumerable<string> SplitStringBy(string str, int chunkLength)
		{
			if (String.IsNullOrEmpty(str)) throw new ArgumentException();
			if (chunkLength < 1) throw new ArgumentException();

			for (int i = 0; i < str.Length; i += chunkLength)
			{
				if (chunkLength + i > str.Length)
					chunkLength = str.Length - i;

				yield return str.Substring(i, chunkLength);
			}
		}

	}
}
