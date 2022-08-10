using System.Collections;

namespace NPLC.Assignment5.Exercise1
{
	internal class Program
	{
		public static void Main(string[] args)
		{
			ArrayList arr = new ArrayList() { "Hung", "Vu", 1, 2, "Van", 3.9d };

			Console.WriteLine($"Number of Int element in the array: {arr.CountInt()}");

			Console.WriteLine($"Max value of Array: {arr.MaxOf<int>()}");

			Console.WriteLine($"Number of {typeof(string)} element in the Array: {arr.CountOf<string>()}");

		}
	}
}