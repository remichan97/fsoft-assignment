namespace NPL.M.A001.Exercise1
{
	internal class Program
	{
		private static int EvaluatePolynominal(int[] poly, int x, int length)
		{
			int result;

			result = poly[0];

			for (var i = 1; i < length; i++)
			{
				result = result * x + poly[i];
			}

			return result;
		}
		public static void Main(string[] args)
		{
			Console.WriteLine("Enter the first number:");
			int num1 = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("Enter the second number:");
			int num2 = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("Enter the third number:");
			int num3 = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("Enter the fourth number:");
			int num4 = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("Enter x:");
			int x = Convert.ToInt32(Console.ReadLine());
			int[] polynominal = { num1, num2, num3, num4 };
			int length = polynominal.Length;

			Console.WriteLine($"Value of the polynominal: {EvaluatePolynominal(polynominal, x, length)}");
			
		}
	}

}