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
	public enum RegistryTree
	{
		ClassesRoot,
		CurrentUser,
		LocalMachine,
		Users,
		CurrentConfig,
		PerformanceData,
	}


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
		private static RegistryKey[] registryTrees = {
			Registry.ClassesRoot,
			Registry.CurrentUser,
			Registry.LocalMachine,
			Registry.Users,
			Registry.CurrentConfig,
			Registry.PerformanceData};


		public static void Load(object data, string keyName)
		{
			Load(data, RegistryTree.CurrentUser, keyName);
		}

		public static void Load(object data, RegistryTree tree, string keyName)
		{
			RegistryKey rootKey = registryTrees[(int)tree].OpenSubKey(keyName);
			if (rootKey != null)
			{
				Load(data, rootKey);
				rootKey.Close();
			}
		}

		public static void Save(object data, string keyName)
		{
			Save(data, RegistryTree.CurrentUser, keyName);
		}

		public static void Save(object data, RegistryTree tree, string keyName)
		{
			Save(data, registryTrees[(int)tree], keyName);
		}


		public static void Load(object data, RegistryKey key)
		{
			foreach (var propertyInfo in data.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public))
			{
				RegistrySaveAttribute valueAttr = GetAttribute<RegistrySaveAttribute>(propertyInfo);
				if (valueAttr != null)
				{
					if (valueAttr.IsObject)
					{
						RegistryKey subkey = key.OpenSubKey(valueAttr.Name);
						if (subkey != null)
						{
							// Try to get an existing value of the property.
							object value = propertyInfo.GetValue(data, null);

							// In the property has no value, and the subkey exists, create a new value object.
							if (value == null)
							{
								value = Activator.CreateInstance(propertyInfo.PropertyType);
								propertyInfo.SetValue(data, value, null);
							}

							// Load the value members (no matter whether the value existed or has been created).
							Load(value, subkey);

							// Close the subkey.
							subkey.Close();
						}
						else
						{
							// If there's no subkey, erase the object.
							propertyInfo.SetValue(data, null, null);
						}
					}
					else
					{
						// Load the simple value.
						string strValue = key.GetValue(valueAttr.Name) as string;
						object value = strValue != null ? InvariantConverter.FromString(strValue, propertyInfo.PropertyType) : valueAttr.DefaultValue;
						propertyInfo.SetValue(data, value, null);
					}
				}
			}
		}

		private static void Save(object data, RegistryKey root, string keyName)
		{
			RegistryKey currentKey = root.CreateSubKey(keyName);
			if (currentKey != null)
			{
				foreach (var propertyInfo in data.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public))
				{
					RegistrySaveAttribute valueAttr = GetAttribute<RegistrySaveAttribute>(propertyInfo);
					if (valueAttr != null)
					{
						object value = propertyInfo.GetValue(data, null);

						if (valueAttr.IsObject)
						{
							if (value == null)
							{
								root.DeleteSubKey(keyName + '\\' + valueAttr.Name);
							}
							else
							{
								Save(value, root, keyName + '\\' + valueAttr.Name);
							}
						}
						else
						{
							currentKey.SetValue(valueAttr.Name, InvariantConverter.ToString(value));
						}

						//if (propertyInfo.PropertyType.GetInterface(IList.GetType().ToString()) != null)
					}
				}

				// All done.
				currentKey.Close();
			}
		}


		private static TAttr GetAttribute<TAttr>(PropertyInfo propertyInfo) where TAttr : Attribute
		{
			object[] attributes = propertyInfo.GetCustomAttributes(typeof(TAttr), false);
			return attributes.Length > 0 ? (TAttr)attributes[0] : null;
		}
	}
}
