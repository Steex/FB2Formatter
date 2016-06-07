using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Windows.Forms;


namespace FB2Formatter
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}


		private void panelFormatPicturesDroplet_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent("FileDrop"))
			{
				e.Effect = DragDropEffects.Link;
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}
		}

		private void panelFormatPicturesDroplet_DragDrop(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent("FileDrop"))
			{
				string[] paths = (string[])e.Data.GetData("FileDrop");

				foreach (string path in paths.Where(p => Path.GetExtension(p) == ".fb2" && File.Exists(p)))
				{
					string sourceFile = path;
					string targetFile = Path.Combine(Path.GetDirectoryName(path), Path.GetFileNameWithoutExtension(path) + "_images.txt");
					BookUtils.FormatBookPictures(sourceFile, targetFile);
				}
			}
		}

		private void panelExtractPicturesDroplet_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent("FileDrop"))
			{
				e.Effect = DragDropEffects.Link;
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}
		}

		private void panelExtractPicturesDroplet_DragDrop(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent("FileDrop"))
			{
				string[] paths = (string[])e.Data.GetData("FileDrop");

				foreach (string path in paths.Where(p => Path.GetExtension(p) == ".fb2" && File.Exists(p)))
				{
					string sourceFile = path;
					string targetFolder = Path.ChangeExtension(path, "");
					BookUtils.ExtractBookPictures(sourceFile, targetFolder);
				}
			}
		}

		private void panelComposePicturesDroplet_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent("FileDrop"))
			{
				e.Effect = DragDropEffects.Link;
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}
		}

		private void panelComposePicturesDroplet_DragDrop(object sender, DragEventArgs e)
		{
			string[] pictureExtensions = new string[] { ".png", ".jpg", ".jpeg" };

			if (e.Data.GetDataPresent("FileDrop"))
			{
				string[] paths = (string[])e.Data.GetData("FileDrop");

				IEnumerable<string> folders = paths.Where(p => Directory.Exists(p));
				IEnumerable<string> pictures = paths.Where(p => pictureExtensions.Contains(Path.GetExtension(p)));

				if (folders.Any() && !pictures.Any())
				{
					foreach (string folder in folders)
					{
						BookUtils.ComposeFolderPictures(folder, folder + "_images.txt");
					}
				}
				else if (!folders.Any() && pictures.Any())
				{
					BookUtils.ComposeListPictures(pictures, Path.Combine(Path.GetDirectoryName(pictures.First()), "images.txt"));
				}
			}
		}

	}
}
