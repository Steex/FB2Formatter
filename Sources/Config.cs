using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing.Imaging;
using System.Reflection;
using System.ComponentModel;
using Microsoft.Win32;

namespace FB2Formatter
{
	public class RegistrySaveNameAttribute : Attribute
	{
		public string Name { get; private set; }

		public RegistrySaveNameAttribute(string name)
		{
			Name = name;
		}
	}

	public class Config
	{
		private static readonly string registryRootName = @"Software\SteexSoft\FB2Formatter";

		// Data fields.
		private bool indentIsTab;

		// Properties.
		public bool IndentIsTab { get { return indentIsTab; } set { indentIsTab = value; IndentChar = indentIsTab ? '\t' : ' '; } }
		[Browsable(false)]
		public char IndentChar { get; private set; }
		public int IndentLength { get; set; }
		public int BinaryLineSize { get; set; }

		public bool FormatNotes { get; set; }
		public bool RenumberNotes { get; set; }
		public bool FormatComments { get; set; }
		public bool RenumberComments { get; set; }


		// The config used by application.
		public static Config Main { get; private set; }


		static Config()
		{
			Main = new Config();
		}

		private Config()
		{
			IndentIsTab = false;
			IndentLength = 1;
			BinaryLineSize = 80;
		}

		public Config Clone()
		{
			Config copy = new Config();

			copy.IndentIsTab = IndentIsTab;
			copy.IndentLength = IndentLength;
			copy.BinaryLineSize = BinaryLineSize;

			copy.FormatNotes = FormatNotes;
			copy.RenumberNotes = RenumberNotes;
			copy.FormatComments = FormatComments;
			copy.RenumberComments = RenumberComments;

			return copy;
		}


		public static void SetMain(Config config)
		{
			Main = config.Clone();
		}


		public void Load()
		{
			RegistryKey settingsRoot = Registry.CurrentUser.OpenSubKey(registryRootName);
			if (settingsRoot != null)
			{
				IndentIsTab = Utils.ReadRegistryValue(settingsRoot, "IndentIsTab", IndentIsTab);
				IndentLength = Utils.ReadRegistryValue(settingsRoot, "IndentLength", IndentLength);
				BinaryLineSize = Utils.ReadRegistryValue(settingsRoot, "BinaryLineSize", BinaryLineSize);

				FormatNotes = Utils.ReadRegistryValue(settingsRoot, "FormatNotes", FormatNotes);
				RenumberNotes = Utils.ReadRegistryValue(settingsRoot, "RenumberNotes", RenumberNotes);
				FormatComments = Utils.ReadRegistryValue(settingsRoot, "FormatComments", FormatComments);
				RenumberComments = Utils.ReadRegistryValue(settingsRoot, "RenumberComments", RenumberComments);

				// All done.
				settingsRoot.Close();
			}
		}

		public void Save()
		{
			try
			{
				RegistryKey settingsRoot = Registry.CurrentUser.CreateSubKey(registryRootName);
				if (settingsRoot != null)
				{
					Utils.WriteRegistryValue(settingsRoot, "IndentIsTab", IndentIsTab);
					Utils.WriteRegistryValue(settingsRoot, "IndentLength", IndentLength);
					Utils.WriteRegistryValue(settingsRoot, "BinaryLineSize", BinaryLineSize);

					Utils.WriteRegistryValue(settingsRoot, "FormatNotes", FormatNotes);
					Utils.WriteRegistryValue(settingsRoot, "RenumberNotes", RenumberNotes);
					Utils.WriteRegistryValue(settingsRoot, "FormatComments", FormatComments);
					Utils.WriteRegistryValue(settingsRoot, "RenumberComments", RenumberComments);

					// All done.
					settingsRoot.Close();
				}
			}
			catch
			{
			}
		}


		public void SaveReflection()
		{
			RegistryKey settingsRoot = Registry.CurrentUser.OpenSubKey(registryRootName);
			if (settingsRoot != null)
			{
				foreach (var propertyInfo in GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public))
				{
					object[] attributes = propertyInfo.GetCustomAttributes(typeof(RegistrySaveNameAttribute), false);
					if (attributes.Length > 0)
					{
						string registryName = ((RegistrySaveNameAttribute)attributes[0]).Name;
						object value = propertyInfo.GetValue(this, null);
						settingsRoot.SetValue(registryName, InvariantConverter.ToString(value));
					}
				}


				// All done.
				settingsRoot.Close();
			}
		}

	}
}
