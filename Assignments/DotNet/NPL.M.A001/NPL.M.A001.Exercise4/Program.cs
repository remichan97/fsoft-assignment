namespace NPL.M.A001.Exercise4
{
    internal class Program
    {
        private static void CheckPrimeNumber(int number)
        {
			int count = 0;

            if (number <= 1)
            {
                Console.WriteLine($"{number} is not a prime number");
				return;
			}

            for (int i = 2; i < Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
					count = 1;
					break;
				}
            }

            if (count == 1)
            {
                Console.WriteLine($"{number} is not a prime number");
            }
            else
            {
                Console.WriteLine($"{number} is a prime number");
            }

		}

        public static void Main(string[] args)
        {
            Console.Write("Enter a prime number to check prime: ");
			int number = Convert.ToInt32(Console.ReadLine());
			CheckPrimeNumber(number);
		}
    }
}