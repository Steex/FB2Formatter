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


		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			Config.Main.Load();
		}


		protected override void OnClosed(EventArgs e)
		{
			Config.Main.Save();

			base.OnClosed(e);
		}


		private void droplet_DragEnter(object sender, DragEventArgs e)
		{
			e.Effect = e.Data.GetDataPresent("FileDrop") ? DragDropEffects.Link : DragDropEffects.None;

		}


		private void dropletFormatBooks_DragDrop(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent("FileDrop"))
			{
				string[] paths = (string[])e.Data.GetData("FileDrop");

				foreach (string path in paths.Where(p => Path.GetExtension(p) == ".fb2" && File.Exists(p)))
				{
					string sourceFile = path;
					string targetFile = Path.Combine(Path.GetDirectoryName(path), Path.GetFileNameWithoutExtension(path) + "_fmt.fb2");
					BookUtils.FormatBook(sourceFile, targetFile);
				}
			}
		}

		private void dropletFormatBookPictures_DragDrop(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent("FileDrop"))
			{
				string[] paths = (string[])e.Data.GetData("FileDrop");

				foreach (string path in paths.Where(p => Path.GetExtension(p) == ".fb2" && File.Exists(p)))
				{
					string sourceFile = path;
					string targetFile = Path.Combine(Path.GetDirectoryName(path), Path.GetFileNameWithoutExtension(path) + "_fmt.fb2");
					BookUtils.FormatBookPictures(sourceFile, targetFile);
				}
			}
		}

		private void dropletExtractPicturesToXml_DragDrop(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent("FileDrop"))
			{
				string[] paths = (string[])e.Data.GetData("FileDrop");

				foreach (string path in paths.Where(p => Path.GetExtension(p) == ".fb2" && File.Exists(p)))
				{
					string sourceFile = path;
					string targetFile = Path.Combine(Path.GetDirectoryName(path), Path.GetFileNameWithoutExtension(path) + "_images.txt");
					BookUtils.ExtractPicturesToXml(sourceFile, targetFile);
				}
			}
		}

		private void dropletExtractPicturesToFiles_DragDrop(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent("FileDrop"))
			{
				string[] paths = (string[])e.Data.GetData("FileDrop");

				foreach (string path in paths.Where(p => Path.GetExtension(p) == ".fb2" && File.Exists(p)))
				{
					string sourceFile = path;
					string targetFolder = Path.ChangeExtension(path, null);
					BookUtils.ExtractPicturesToFiles(sourceFile, targetFolder);
				}
			}
		}

		private void dropletConvertPicturesToXml_DragDrop(object sender, DragEventArgs e)
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
						BookUtils.ConvertFolderPicturesToXml(folder, folder + "_images.txt");
					}
				}
				else if (!folders.Any() && pictures.Any())
				{
					BookUtils.ConvertListPicturesToXml(pictures, Path.Combine(Path.GetDirectoryName(pictures.First()), "images.txt"));
				}
			}
		}

		private void menuExit_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void menuOptions_Click(object sender, EventArgs e)
		{
			SettingsForm settingsForm = new SettingsForm();
			settingsForm.ShowDialog(this);
		}

	}
}
