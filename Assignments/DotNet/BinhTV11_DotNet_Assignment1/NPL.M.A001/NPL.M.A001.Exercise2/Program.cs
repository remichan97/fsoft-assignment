namespace NPL.M.A001.Exercise2
{
	internal class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Enter a number to convert to binary: ");
			int input = Convert.ToInt32((Console.ReadLine()));

			string binary = Convert.ToString(input, 2);

			Console.WriteLine("Binary: " + binary);
		}
	}
}
