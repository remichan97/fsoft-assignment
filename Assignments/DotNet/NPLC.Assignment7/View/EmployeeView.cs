using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NPLC.Assignment7.Controllers;

namespace NPLC.Assignment7.View
{
	public class EmployeeView
	{
		internal static void GetDepartments(int numberOfEmployees)
		{
			var list = EmployeeController.GetDepartments(numberOfEmployees);

			if (list is null)
			{
				Console.WriteLine($"Your query returns no results. Either no department added or no Department satisfied the query you're looking for");

			}
			else
			{
				Console.WriteLine($"List of Departments satisfied the query:");

				list.ForEach(it => Console.WriteLine($"{it}"));
			}
		}

		internal static void GetEmployeeWorking()
		{
			var list = EmployeeController.GetEmployeeWorking();

			if (list is null)
			{
				Console.WriteLine($"Your query returns no results");
			}
			else
			{
				Console.WriteLine($"Currently working Employee:");
				list.ForEach(it => it.ToString());
			}
		}

		internal static void GetLanguages(int employeeId)
		{
			var list = EmployeeController.GetLanguages(employeeId);

			if (list is null)
			{
				Console.WriteLine($"Your query returns no results");
			}
			else
			{
				Console.WriteLine($"The following is the list of programming languages the selected employee is using");
				list.ForEach(it => Console.WriteLine($"{it}"));
			}
		}

        internal static void GetSeniorEmployee()
        {
			var list = EmployeeController.GetSeniorEmployee();

            if (list is null)
            {
				Console.WriteLine($"Your query returns no results");
            }
            else
            {
                Console.WriteLine($"List of Senior Employee");
				list.ForEach(it => it.ToString());
			}
		}

        internal static void GetEmployeePaging(int pageIndex, int pageSize, string order)
        {
			var list = EmployeeController.GetEmployeePaging(pageIndex, pageSize, order);

            if (list is null)
            {
                Console.WriteLine($"Something went wrong!");
            }
            else
            {
				list.ForEach(it => it.ToString());
			}
		}
	}
}