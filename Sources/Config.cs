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
	public class ConfigData
	{
		// Data fields.
		private bool indentIsTab;

		// Properties.
		[RegistrySave("IndentIsTab", false, false)]
		public bool IndentIsTab { get { return indentIsTab; } set { indentIsTab = value; IndentChar = indentIsTab ? '\t' : ' '; } }
		[Browsable(false)]
		public char IndentChar { get; private set; }
		[RegistrySave("IndentLength", false, 1)]
		public int IndentLength { get; set; }
		[RegistrySave("BinaryLineSize", false, 80)]
		public int BinaryLineSize { get; set; }

		[RegistrySave("FormatNotes", false, false)]
		public bool FormatNotes { get; set; }
		[RegistrySave("RenumberNotes", false, false)]
		public bool RenumberNotes { get; set; }
		[RegistrySave("FormatComments", false, false)]
		public bool FormatComments { get; set; }
		[RegistrySave("RenumberComments", false, false)]
		public bool RenumberComments { get; set; }


		public ConfigData()
		{
			IndentIsTab = false;
			IndentLength = 1;
			BinaryLineSize = 80;
		}

		public ConfigData Clone()
		{
			ConfigData copy = new ConfigData();

			copy.IndentIsTab = IndentIsTab;
			copy.IndentLength = IndentLength;
			copy.BinaryLineSize = BinaryLineSize;

			copy.FormatNotes = FormatNotes;
			copy.RenumberNotes = RenumberNotes;
			copy.FormatComments = FormatComments;
			copy.RenumberComments = RenumberComments;

			return copy;
		}


		public void Load(string key)
		{
			RegistrySaver.Load(this, key);
		}

		public void Save(string key)
		{
			try
			{
				RegistrySaver.Save(this, key);
			}
			catch
			{
			}
		}

	}


	public static class Config
	{
		private static readonly string registryRootName = @"Software\SteexSoft\FB2Formatter";


		// The config used by application.
		public static ConfigData Main { get; private set; }


		static Config()
		{
			Main = new ConfigData();
		}

		public static void SetMain(ConfigData data)
		{
			Main = data.Clone();
		}


		public static void Load()
		{
			Main.Load(registryRootName);
		}

		public static void Save()
		{
			Main.Save(registryRootName);
		}

	}
}
