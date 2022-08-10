namespace NPLC.Assignment5.Exercise3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
			int[] intArr = new int[] { 1, 2, 3, 5, 7, 3, 2 };

			Console.WriteLine($"Last index of value 3: {intArr.LastIndexOf(3)}");

			string[] stringArr = new string[] { "Nguyen", "Van", "A", "Vu", "Van", "Hung" };
            Console.WriteLine($"Last index of value Van: {stringArr.LastIndexOf("Van")}");
            
		}
    }
}