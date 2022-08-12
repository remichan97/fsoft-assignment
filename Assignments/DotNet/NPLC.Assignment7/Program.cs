using NPLC.Assignment7.Controllers;
using NPLC.Assignment7.View;

internal class Program
{
	public static void Main(string[] args)
	{
		while (true)
		{
			EmployeeController.AppMenu();
			int opt = Convert.ToInt32(Console.ReadLine());

			switch (opt)
			{
				case 1:
					EmployeeController.AddProgrammingLanguage();
					break;
				case 2:
					EmployeeController.AddDepartment();
					break;
				case 3:
					EmployeeController.AddEmployeee();
					break;
				case 4:
					Console.WriteLine($"Enter number of Employees to search Department: ");
					int count = Convert.ToInt32(Console.ReadLine());
					while (count < 1)
					{
						Console.WriteLine($"Invalid number. It cannot be smaller than 1. Please try again!");
						Console.WriteLine($"Enter number of Employees to search Department: ");
						count = Convert.ToInt32(Console.ReadLine());
					}
					EmployeeView.GetDepartments(count);
					break;
				case 5:
					EmployeeView.GetEmployeeWorking();
					break;
				case 6:
					Console.WriteLine($"Enter Employee ID to search:");
					int empId = Convert.ToInt32(Console.ReadLine());
					EmployeeView.GetLanguages(empId);
					break;
				case 7:
					EmployeeView.GetSeniorEmployee();
					break;
				case 8:
					int pageIndex, pageSize;
					string order;
					Console.WriteLine($"Which page you wishes to view:");
					pageIndex = Convert.ToInt32(Console.ReadLine());
					while (pageIndex < 0)
					{
						Console.WriteLine($"Invalid value. Please try again!");
						Console.WriteLine($"Which page you wishes to view:");
						pageIndex = Convert.ToInt32(Console.ReadLine());
					}
					Console.WriteLine($"How many Employee per page:");
					pageSize = Convert.ToInt32(Console.ReadLine());
					while (pageSize < 0)
					{
						Console.WriteLine($"Invalid value. Please try again!");
						Console.WriteLine($"How many Employee per view:");
						pageSize = Convert.ToInt32(Console.ReadLine());
					}
					Console.WriteLine($"Would you like to sort Ascending (ASC) or Descending (DESC):");
					order = Console.ReadLine()!;

					while (!order!.Equals("ASC") || !order.Equals("DESC"))
					{
						Console.WriteLine($"Invalid option. Please try again!");
						Console.WriteLine($"Would you like to sort Ascending (ASC) or Descending (DESC):");
						order = Console.ReadLine()!;
					}
					EmployeeView.GetEmployeePaging(pageIndex, pageSize, order);
					break;
				case 9:
					EmployeeController.ListDepartments();
					break;
				case 10:
					Environment.Exit(0);
					break;
			}
		}
	}
}