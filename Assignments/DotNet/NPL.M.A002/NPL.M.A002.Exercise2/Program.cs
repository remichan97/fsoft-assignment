namespace NPL.M.A002.Exercise2
{
	internal class Program
	{
		private static void GreatestCommonDivisor(int number1, int number2)
		{
			int rem = 0;

			while (number2 > 0)
			{
				rem = number1 % number2;
				number1 = number2;
				number2 = rem;
			}

			Console.WriteLine($"The greatest common divisor is {number1}");
		}

		static void Main(string[] args)
		{
			Console.WriteLine("Enter the first number: ");
			int number1 = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("Enter the second number: ");
			int number2 = Convert.ToInt32(Console.ReadLine());
			GreatestCommonDivisor(number1, number2);
		}
	}
}