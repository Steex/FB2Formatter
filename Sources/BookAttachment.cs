using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;


namespace FB2Formatter
{
	public class BookAttachment
	{
		public string Name { get; private set; }
		public string FileName { get; private set; }
		public string Format { get; private set; }
		public byte[] Content { get; private set; }

		public BookAttachment(XmlElement xml)
		{
			if (!xml.HasAttribute("id"))
			{
				throw new Exception("Image XML element must have the \"id\" attribute.");
			}

			if (!xml.HasAttribute("content-type"))
			{
				throw new Exception("Image XML element must have the \"content-type\" attribute.");
			}

			Name = xml.GetAttribute("id");
			Format = xml.GetAttribute("content-type");
			Content = Convert.FromBase64String(xml.InnerText);

			// Format the file name
			if (Path.HasExtension(Name))
			{
				FileName = Name;
			}
			else if (Format == "image/png")
			{
				FileName = Name + ".png";
			}
			else if (Format == "image/jpeg")
			{
				FileName = Name + ".jpg";
			}
			else
			{
				FileName = Name;
			}
		}

		public BookAttachment(string filePath)
		{
			if (!File.Exists(filePath))
			{
				throw new Exception("The specified file not exists.\r\nFile: \"" + filePath + "\"");
			}

			switch (Path.GetExtension(filePath))
			{
				case ".png": Format = "image/png"; break;
				case ".jpg": Format = "image/jpeg"; break;
				case ".jpeg": Format = "image/jpeg"; break;
				default: Format = "application/octet-stream"; break;
			}

			Name = Path.GetFileName(filePath);
			FileName = Name;
			Content = File.ReadAllBytes(filePath);
		}
	}
}
