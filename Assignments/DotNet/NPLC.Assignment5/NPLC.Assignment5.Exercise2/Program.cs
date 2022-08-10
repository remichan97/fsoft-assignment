namespace NPLC.Assignment5.Exercise2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
			int[] intArr = new int[] {1, 2, 3, 3, 5, 6, 5, 2 };

            int[] newArr = intArr.RemoveDuplicate();

			Console.WriteLine($"New int array after removed any duplicate:");
            
            foreach (var item in newArr)
            {
                Console.WriteLine(item);
                
            }


			string[] stringArr = new string[] {"Hung", "Vu", "Van", "Hung", "Quang", "Huy", "Vu"};
			string[] newStringArr = stringArr.RemoveDuplicate<string>();

			Console.WriteLine($"New string array after removed any duplicate:");

            foreach (var item in newStringArr)
            {
                Console.WriteLine($"{item}");
            }
		}
    }
}