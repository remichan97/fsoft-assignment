using NPLC.Assignment3.Controller;

namespace NPLC.Assignment3
{
	internal class Program
	{

		public static void Main(string[] args)
		{
			int opt = 0;
			while (true)
			{
				DepartmentManage.Menu();
				
				try
				{
					opt = Convert.ToInt32(Console.ReadLine());
				}
				catch (Exception)
				{
					Console.WriteLine($"Input is not a number. Try again");
				}

				switch (opt)
				{
					case 1:
						DepartmentManage.AddMenu();
						int choice = Convert.ToInt32(Console.ReadLine());
						switch (choice)
						{
							case 1:
								DepartmentManage.AddHourlyEmployee();
								break;
							case 2:
								DepartmentManage.AddSalariedEmployee();
								break;
						}
						break;
					case 2:
						DepartmentManage.DisplayEmployee();
						break;
					case 3:
						Console.WriteLine($"Enter a keyword to search: ");
						string keyword = Console.ReadLine()!;
						DepartmentManage.Search(keyword);
						break;
					case 4:
						DepartmentManage.Count();
						break;
					case 5:
						Environment.Exit(0);
						break;
				}
			}

		}
	}
}