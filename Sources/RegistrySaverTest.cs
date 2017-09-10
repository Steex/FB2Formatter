using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Win32;

namespace FB2Formatter
{
	public enum TempEnum
	{
		First,
		Second,
		Third,
	}


	public class TempSubdata
	{
		[RegistrySave("Name", false, "")]
		public string Name { get; set; }
		[RegistrySave("Value", false, "")]
		public string Value { get; set; }

		public TempSubdata()
		{
		}

		public TempSubdata(string name, string value)
		{
			Name = name;
			Value = value;
		}
	}


	public class TempData
	{
		public List<int> ListData { get; set; }
		[RegistrySave("BoolData", false, false)]
		public bool BoolData { get; set; }
		[RegistrySave("IntData", false, 99)]
		public int IntData { get; set; }
		[RegistrySave("FloatData", false, 99.99f)]
		public float FloatData { get; set; }
		[RegistrySave("StringData", false, "yo!")]
		public string StringData { get; set; }
		[RegistrySave("EnumData", false, TempEnum.First)]
		public TempEnum EnumData { get; set; }
		[RegistrySave("ObjectData", true, null)]
		public TempSubdata ObjectData { get; set; }

		public TempData()
		{
			ListData = new List<int>();
			BoolData = true;
			IntData = 5;
			FloatData = 3.1415f;
			StringData = "simple sample";
			EnumData = TempEnum.Second;
			ObjectData = new TempSubdata("my-name", "my-value");
		}
	}


	public static class RegistrySaverTest
	{
		private static readonly string registryRootName = @"Software\SteexSoft\RegistrySaver";

		public static void DoTest()
		{
			TempData data1 = new TempData();
			data1.BoolData = false;
			data1.IntData = 77;
			data1.FloatData = 0.123f;
			data1.StringData = "bzzzz";
			data1.EnumData = TempEnum.Third;
			data1.ObjectData.Name = "WTF";
			data1.ObjectData.Value = "OMG";
			RegistrySaver.Save(data1, registryRootName);

			TempData data2 = new TempData();
			data2.ObjectData = null;
			RegistrySaver.Load(data2, registryRootName);
		}
	}
}
