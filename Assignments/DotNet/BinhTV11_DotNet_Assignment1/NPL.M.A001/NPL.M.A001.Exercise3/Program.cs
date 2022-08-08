namespace NPL.M.A001.Exercise3
{
	internal class Program
	{
		private static void PrintFibonacci(int number)
		{
			int prevNumber = 1, newNumber = 1, sum;
			Console.WriteLine(prevNumber);
			Console.WriteLine(newNumber);
			for (int i = 2; i < number; i++)
            {
				sum = prevNumber + newNumber;
				prevNumber = newNumber;
				newNumber = sum;
				Console.WriteLine(newNumber);
			}
		}

		public static void Main(string[] args)
		{
			Console.Write("Enter a number of Fibonacci you wish to print: ");
			int number = Convert.ToInt32(Console.ReadLine());
			PrintFibonacci(number);
		}
	}
}