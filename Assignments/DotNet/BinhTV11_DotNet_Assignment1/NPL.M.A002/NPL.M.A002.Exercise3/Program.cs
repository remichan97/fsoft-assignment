namespace NPL.M.A002.Exercise3
{
	internal class Program
	{
        private static int FindGreatestCommonDivider(int number1, int number2)
        {
            int rem = 0;

			while (number2 > 0)
			{
				rem = number1 % number2;
				number1 = number2;
				number2 = rem;
			}
			return number1;
		}
        private static int GreatestCommonDivider(int[] arr)
        {
			return arr.Aggregate(FindGreatestCommonDivider);
		}

		public static void Main(string[] args)
		{
			Console.Write("Enter number of elements to add in the array: ");
			int numOfElement = Convert.ToInt32(Console.ReadLine());
			int[] arr = new int[numOfElement];
			for (var i = 0; i < numOfElement; i++)
			{
				Console.WriteLine($"Element #{i + 1}: ");
				int elements = Convert.ToInt32(Console.ReadLine());
				arr[i] = elements;
			}

			GreatestCommonDivider(arr);
		}
	}
}