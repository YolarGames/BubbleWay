using UnityEngine;

namespace YolarUtils.SmartLogger
{
	public static class LogStyles
	{
		private const string WhiteColor = "<color=white>";
		private const string YellowColor = "<color=yellow>";
		private const string CyanColor = "<color=cyan>";
		private const string GreenColor = "<color=green>";
		private const string RedColor = "<color=red>";
		private const string BlueColor = "<color=blue>";
		private const string MagentaColor = "<color=magenta>";
		private const string ColorClose = "</color>";
		private const string BoldOpen = "<b>";
		private const string BoldClose = "</b>";

		public static string ClearStyles(this string value)
		{
			for (var i = 0; i < 100; i++)
				if (HasTags(in value))
				{
					ExtractOpenTag(ref value);
					ExtractCloseTag(ref value);
				}
				else
					break;

			return value;
		}

		public static string Bold(this string value) =>
			Application.isEditor ? BoldOpen + value + BoldClose : value;

		public static string White(this string value) =>
			Colored(value, WhiteColor);

		public static string Yellow(this string value) =>
			Colored(value, YellowColor);

		public static string Cyan(this string value) =>
			Colored(value, CyanColor);

		public static string Green(this string value) =>
			Colored(value, GreenColor);

		public static string Red(this string value) =>
			Colored(value, RedColor);

		public static string Blue(this string value) =>
			Colored(value, BlueColor);

		public static string Magenta(this string value) =>
			Colored(value, MagentaColor);

		private static void ExtractOpenTag(ref string name)
		{
			string substring = name.Substring(name.IndexOf('<'), name.IndexOf('>') - name.IndexOf('<') + 1);
			name = name.Replace(substring, string.Empty);
		}

		private static void ExtractCloseTag(ref string name)
		{
			string substring = name.Substring(name.LastIndexOf('<'), name.LastIndexOf('>') - name.LastIndexOf('<') + 1);
			name = name.Replace(substring, string.Empty);
		}

		private static bool HasTags(in string name) =>
			name.IndexOf('<') != -1;

		private static string Colored(this string value, string color) =>
			Application.isEditor ? color + value + ColorClose : value;
	}
}