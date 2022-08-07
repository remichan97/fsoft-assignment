using System.Globalization;
using System.Text.RegularExpressions;

namespace NPL.M.A005.Exercise1
{
	internal class Program
	{
		private static string NormaliseName(string name)
		{
			if (name is null || String.IsNullOrEmpty(name))
			{
				throw new Exception("Name cannot be empty!");
			}

			CultureInfo info = new CultureInfo("vi-VN");

			TextInfo textInfo = info.TextInfo;

			string str = textInfo.ToLower(name);

			str = Regex.Replace(str, @"\s{2,}", " ");

			return textInfo.ToTitleCase(str);
		}
		public static void Main(string[] args)
		{
			Console.WriteLine("Enter a name to normalise: ");
			string name = Console.ReadLine()!;
			Console.WriteLine($"Normalised name: {(NormaliseName(name))}");
		}
	}
}