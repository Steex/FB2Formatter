using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace FB2Formatter
{
	public static class Utils
	{
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
