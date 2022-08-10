namespace NPLC.Assignment5.Exercise4
{
    internal class Program
    {
        public static void Main(string[] args)
        {
			int[] arr = new int[] { 3, 2, 5, 6, 1, 7, 7, 5, 2 };

			Console.WriteLine($"{arr.ElementOfOrder2()}");
			Console.WriteLine($"{arr.ElementOfOrder(2)}");
			Console.WriteLine($"{arr.ElementOfOrder(3)}");
			Console.WriteLine($"{arr.ElementOfOrder(20)}");
        }
    }
}