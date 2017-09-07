using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace FB2Formatter
{
	public enum TempEnum
	{
		First,
		Second,
		Third,
	}


	public class TempObject
	{
		public int n = 42;
	}


	public class TempData
	{
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
		//[RegistrySaveName("ObjectData")]
		public TempObject ObjectData { get; set; }

		public TempData()
		{
			BoolData = true;
			IntData = 5;
			FloatData = 3.1415f;
			StringData = "simple sample";
			EnumData = TempEnum.Second;
			ObjectData = new TempObject();
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
			//RegistrySaver.Save(data1, registryRootName);

			TempData data2 = new TempData();
			RegistrySaver.Load(data2, registryRootName);
		}
	}
}
