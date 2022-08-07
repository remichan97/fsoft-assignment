namespace NPLC.Assignment1.Opt2.Exercise1
{
	internal class Program
	{
        private static void SendReminder(DateTime date)
        {
			DateTime newData = date.AddDays(7);
			Console.WriteLine($"First reminder at {newData}");
			DateTime newDate = newData.AddDays(2);
			Console.WriteLine($"Second reminder at {newDate}");
			for (int i = 1; i <= 3; i++)
			{
				Console.WriteLine($"Next reminder at {newDate.AddDays(i)}");
			}
			
        }

		public static void Main(string[] args)
		{
			Console.WriteLine("Enter a date to start sending reminder");
			DateTime date = Convert.ToDateTime(Console.ReadLine());
			SendReminder(date);
		}
	}
}