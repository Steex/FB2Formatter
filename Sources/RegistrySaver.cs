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
	public class RegistrySaveAttribute : Attribute
	{
		public string Name { get; private set; }
		public bool IsObject { get; private set; }
		public object DefaultValue { get; private set; }

		public RegistrySaveAttribute(string name, bool isObject, object defaultValue)
		{
			Name = name;
			IsObject = isObject;
			DefaultValue = defaultValue;
		}
	}


	public class RegistrySaver
	{
		public static void Load(object data, string registryRootName)
		{
			RegistryKey settingsRoot = Registry.CurrentUser.OpenSubKey(registryRootName);
			if (settingsRoot != null)
			{
				foreach (var propertyInfo in data.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public))
				{
					object[] attributes = propertyInfo.GetCustomAttributes(typeof(RegistrySaveAttribute), false);
					if (attributes.Length > 0)
					{
						RegistrySaveAttribute attr = ((RegistrySaveAttribute)attributes[0]);
						string registryValue = settingsRoot.GetValue(attr.Name) as string;
						object value = registryValue != null ? InvariantConverter.FromString(registryValue, propertyInfo.PropertyType) : attr.DefaultValue;
						propertyInfo.SetValue(data, value, null);
					}
				}

				// All done.
				settingsRoot.Close();
			}
		}

		public static void Save(object data, string registryRootName)
		{
			RegistryKey settingsRoot = Registry.CurrentUser.CreateSubKey(registryRootName);
			if (settingsRoot != null)
			{
				foreach (var propertyInfo in data.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public))
				{
					object[] attributes = propertyInfo.GetCustomAttributes(typeof(RegistrySaveAttribute), false);
					if (attributes.Length > 0)
					{
						RegistrySaveAttribute attr = ((RegistrySaveAttribute)attributes[0]);
						object value = propertyInfo.GetValue(data, null);
						settingsRoot.SetValue(attr.Name, InvariantConverter.ToString(value));
					}
				}

				// All done.
				settingsRoot.Close();
			}
		}

	}
}
