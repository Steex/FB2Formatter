using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;


namespace FB2Formatter
{
	public static class BookUtils
	{
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


		public static void ExtractBookPictures(string sourceFile, string targetFolder)
		{
			XmlDocument book = OpenBook(sourceFile);

			Directory.CreateDirectory(targetFolder);

			foreach (BookAttachment picture in EnumBookPictures(book))
			{
				File.WriteAllBytes(Path.Combine(targetFolder, picture.FileName), picture.Content);
			}
		}

		public static void FormatBookPictures(string sourceFile, string targetFile)
		{
			XmlDocument book = OpenBook(sourceFile);

			Encoding encoding = Encoding.GetEncoding((book.FirstChild as XmlDeclaration).Encoding);
			using (StreamWriter wr = new StreamWriter(targetFile, false, encoding))
			{
				foreach (BookAttachment picture in EnumBookPictures(book))
				{
					wr.WriteLine(" <binary content-type=\"{0}\" id=\"{1}\">", picture.Format, picture.Name);

					foreach (string chunk in SplitStringBy(Convert.ToBase64String(picture.Content), 80))
					{
						wr.WriteLine("  " + chunk);
					}

					wr.WriteLine(" </binary>");
				}
			}
		}

		public static void ComposeFolderPictures(string sourceFolder, string targetFile)
		{
			using (StreamWriter wr = new StreamWriter(targetFile, false, Encoding.ASCII))
			{
				foreach (BookAttachment picture in EnumFolderPictures(sourceFolder))
				{
					wr.WriteLine(" <binary content-type=\"{0}\" id=\"{1}\">", picture.Format, picture.Name);

					foreach (string chunk in SplitStringBy(Convert.ToBase64String(picture.Content), 80))
					{
						wr.WriteLine("  " + chunk);
					}

					wr.WriteLine(" </binary>");
				}
			}
		}

		public static void ComposeListPictures(IEnumerable<string> sourceFiles, string targetFile)
		{
			using (StreamWriter wr = new StreamWriter(targetFile, false, Encoding.ASCII))
			{
				foreach (string file in sourceFiles)
				{
					BookAttachment picture = new BookAttachment(file);

					wr.WriteLine(" <binary content-type=\"{0}\" id=\"{1}\">", picture.Format, picture.Name);

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
