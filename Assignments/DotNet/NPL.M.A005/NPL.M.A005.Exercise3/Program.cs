namespace NPL.M.A005.Exercise3
{
	internal class Program
	{
		private static void SortNames(string[] arr)
		{
			var sortedList = from names in arr orderby names.Split(" ")[1] ascending select names;

			Console.WriteLine("Sorted List:");
			foreach (var item in sortedList)
			{
				Console.WriteLine(item);
			}
		}

		public static void Main(string[] args)
		{
			Console.WriteLine("How many names you wishes to add in the list?");
			int number = Convert.ToInt32(Console.ReadLine());
			string[] arr = new string[number];
			for (var i = 0; i < number; i++)
			{
				Console.WriteLine($"Enter name #{i + 1}: ");
				string name = Console.ReadLine()!;
				while (String.IsNullOrEmpty(name) || String.IsNullOrWhiteSpace(name))
				{
					Console.WriteLine("Name cannot be empty. Enter another name");
					name = Console.ReadLine()!;
				}
				arr[i] = name;
			}
			SortNames(arr);
		}
	}
}