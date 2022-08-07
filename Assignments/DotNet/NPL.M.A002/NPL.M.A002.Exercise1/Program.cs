namespace NPL.M.A002.Exercise1
{
	internal class Program
	{
        /// <summary>
        /// Sort the array for easier answering
        /// </summary>
        /// <param name="arr">The array to sort</param>
        /// <returns>The sorted array</returns>
		private static int[] SortArray(int[] arr)
		{
			int temp = 0;
			for (int i = 0; i <= arr.Length; i++)
			{
				for (int j = i + 1; j < arr.Length; j++)
				{
					if (arr[i] > arr[j])
					{
						temp = arr[i];
						arr[i] = arr[j];
						arr[j] = temp;
					}
				}
			}
			return arr;
		}

		private static void Answer(int[] arr)
		{
			int[] sortedArr = SortArray(arr);
			Console.WriteLine($"Minimum: {sortedArr[0]}");
			Console.WriteLine($"Maximum: {sortedArr[sortedArr.Length - 1]}");
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
			Answer(arr);
		}
	}
}