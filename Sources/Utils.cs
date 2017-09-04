using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using Microsoft.Win32;

namespace FB2Formatter
{
	public static class Utils
	{
		public static T ReadRegistryValue<T>(RegistryKey key, string name, T defaultValue)
		{
			try
			{
				string strValue = (string)key.GetValue(name, InvariantConverter.ToString(defaultValue));
				return InvariantConverter.FromString<T>(strValue);
			}
			catch
			{
				return defaultValue;
			}
		}

		public static IEnumerable<string> ReadRegistryList(RegistryKey key, string baseName)
		{
			return ReadRegistryList<string>(key, baseName);
		}

		public static IEnumerable<T> ReadRegistryList<T>(RegistryKey key, string baseName)
		{
			for (int index = 1; ; ++index)
			{
				object value = key.GetValue(baseName + index.ToString());
				if (value != null)
				{
					yield return InvariantConverter.FromString<T>(value.ToString());
				}
				else
				{
					break;
				}
			}
		}

		public static void WriteRegistryValue<T>(RegistryKey key, string name, T value)
		{
			if (value != null)
			{
				key.SetValue(name, InvariantConverter.ToString(value));
			}
			else
			{
				key.SetValue(name, "");
			}
		}

		public static void WriteRegistryList<T>(RegistryKey key, string baseName, IEnumerable<T> list)
		{
			if (list != null)
			{
				int index = 1;
				foreach (T item in list)
				{
					Utils.WriteRegistryValue(key, baseName + index.ToString(), InvariantConverter.ToString(item));
					++index;
				}
			}
		}


		public static T DeserializeValueFromRegistry<T>(RegistryKey key, string name, T defaultValue)
		{
			try
			{
				string strValue = (string)key.GetValue(name, InvariantConverter.ToString(defaultValue));
				return DeserializeValue<T>(strValue);
			}
			catch
			{
				return defaultValue;
			}
		}

		public static IEnumerable<T> DeserializeListFromRegistry<T>(RegistryKey key, string baseName)
		{
			for (int index = 1; ; ++index)
			{
				object strValue = key.GetValue(baseName + index.ToString());
				if (strValue is string)
				{
					yield return DeserializeValue<T>((string)strValue);
				}
				else
				{
					break;
				}
			}
		}

		public static void SerializeValueToRegistry<T>(RegistryKey key, string name, T value)
		{
			key.SetValue(name, SerializeValue(value));
		}

		public static void SerializeListToRegistry<T>(RegistryKey key, string baseName, IEnumerable<T> list)
		{
			if (list != null)
			{
				int index = 1;
				foreach (T item in list)
				{
					key.SetValue(baseName + index.ToString(), SerializeValue(item));
					++index;
				}
			}

		}


		public static string SerializeValue(object value)
		{
			if (value == null)
			{
				return "";
			}

			using (MemoryStream stream = new MemoryStream())
			{
				DataContractJsonSerializer serialzer = new DataContractJsonSerializer(value.GetType());
				serialzer.WriteObject(stream, value);
				return Encoding.UTF8.GetString(stream.GetBuffer(), 0, (int)stream.Length);
			}
		}

		public static T DeserializeValue<T>(string data)
		{
			if (string.IsNullOrEmpty(data))
			{
				return default(T);
			}

			using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(data)))
			{
				DataContractJsonSerializer serialzer = new DataContractJsonSerializer(typeof(T));
				return (T)serialzer.ReadObject(stream);
			}
		}


		public static IEnumerable<string> SplitStringBy(string str, int chunkLength)
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
