namespace NPLC.Assignment1.Opt2.Exercise2
{
	internal class Program
	{
		private static void FinancialYear(DateTime startDate, string department, int numberOfInvoice, int numberOfInvoiceDay)
		{
			if (String.IsNullOrEmpty(department) || String.IsNullOrWhiteSpace(department) || department.Length > 3)
			{
				throw new ArgumentException("Invalid department information!");
			}

			if (numberOfInvoice <= 0 || numberOfInvoiceDay <= 0)
			{
				throw new ArgumentException("Number of Invoice/Invoice day cannot be smaller than 1!");
			}

			string depAlias = department.ToUpper();

			string alias = depAlias + "FY" + startDate.Year + "000";

			for (int i = 0; i <= numberOfInvoiceDay; i++)
			{
				for (int f = 1; f <= numberOfInvoice; f++)
				{
					Console.WriteLine($"Invoice Text {startDate.AddDays(i)}: {alias}" + f);

				}
			}
		}

		public static void Main(string[] args)
		{
			Console.WriteLine("Enter a start date:");
			DateTime startDate = Convert.ToDateTime(Console.ReadLine());
			Console.WriteLine("Enter a department name:");
			string department = Console.ReadLine()!;
			Console.WriteLine("Enter a number of invoice in a day:");
			int numberOfInvoice = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("Enter a number of days to print invoice:");
			int numberOfInvoiceDay = Convert.ToInt32(Console.ReadLine());

			FinancialYear(startDate, department, numberOfInvoice, numberOfInvoiceDay);
		}
	}
}