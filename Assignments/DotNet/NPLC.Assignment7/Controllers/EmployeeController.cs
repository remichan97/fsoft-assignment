using NPLC.Assignment7.Models;

namespace NPLC.Assignment7.Controllers
{
	internal class EmployeeController
	{
		private static List<Department> departments;
		private static List<ProgrammingLanguage> programmingLanguages;

		private static List<Employee> employees;

		private static List<EmployeeLanguage> employeeLanguages;
		public EmployeeController()
		{
			departments = new List<Department>();
			programmingLanguages = new List<ProgrammingLanguage>();
			employees = new List<Employee>();
			employeeLanguages = new List<EmployeeLanguage>();
		}
		internal static void AppMenu()
		{
			Console.WriteLine($"Choose an option below:");
			Console.WriteLine($"1. Add a Programming Language");
			Console.WriteLine($"2. Add a Department");
			Console.WriteLine($"3. Add an Employee");
			Console.WriteLine($"4. Get all Departments with more than a certain number of Employees");
			Console.WriteLine($"5. Employees that are currently working");
			Console.WriteLine($"6. List of Employees know a certain language");
			Console.WriteLine($"7. List of Senior Employees");
			Console.WriteLine($"8. Get a Limited list of Employee");
			Console.WriteLine($"9. List of Departments and its Employees");
			Console.WriteLine($"10. Exit");
			Console.Write($"Your choice: ");
		}

		internal static void AddProgrammingLanguage()
		{
			Console.WriteLine($"Enter a Programming Language you wishes to add");
			string languageName = Console.ReadLine();

			ProgrammingLanguage programming = new ProgrammingLanguage() { LanguageName = languageName };

			programmingLanguages.Add(programming);

			Console.WriteLine($"Saved!");
		}

		internal static void AddDepartment()
		{
			Console.WriteLine($"Enter a Department name you wishes to add");
			string departmentName = Console.ReadLine();

			Department department = new Department() { DepartmentName = departmentName };

			departments.Add(department);

			Console.WriteLine($"Saved!");
		}

		internal static void AddEmployeee()
		{
			if (departments.Count == 0)
			{
				Console.WriteLine($"No Department added. Please add a department before adding an Employee!");
				return;
			}
			if (programmingLanguages.Count == 0)
			{
				Console.WriteLine($"No programming language added. Please add a programming languages before adding an Employee!");
				return;
			}
			Console.WriteLine("Employee ID:");
			int empId = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine($"Enter Employee Name: ");
			string empName = Console.ReadLine();
			Console.WriteLine($"Their Age: ");
			int empAge = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine($"Employee current Address: ");
			string empAddress = Console.ReadLine();
			Console.WriteLine($"When were they hired: ");
			DateTime hiredDate = Convert.ToDateTime(Console.ReadLine());
			Console.WriteLine($"Which Department does this Employee belongs to:");
			departments.ForEach(it =>
			{
				Console.WriteLine($"{it.DepartmentId} - {it.DepartmentName}");
			});
			int depId = Convert.ToInt32(Console.ReadLine());
			while (depId < 0 && depId > departments.Count)
			{
				Console.WriteLine($"Invalid option. Please try again");
				Console.WriteLine($"Which Department does this Employee belongs to:");
				departments.ForEach(it =>
				{
					Console.WriteLine($"{it.DepartmentId} - {it.DepartmentName}");
				});
				depId = Convert.ToInt32(Console.ReadLine());
			}

			Employee employee = new Employee() { EmployeeId = empId, EmployeeName = empName, Age = empAge, Address = empAddress, HiredDate = hiredDate, DepartmentId = depId };
			employees.Add(employee);

			Console.WriteLine($"How many programming language does this employee knows?");
			int numOfLang = Convert.ToInt32(Console.ReadLine());
			while (numOfLang < 1 && numOfLang > programmingLanguages.Count)
			{
				Console.WriteLine($"Invalid option. Please try again");
				Console.WriteLine($"How many programming language does this employee knows?");
				numOfLang = Convert.ToInt32(Console.ReadLine());
			}
			for (var i = 1; i <= numOfLang; i++)
			{
				Console.WriteLine($"Choose a language that they know from the list below:");
				programmingLanguages.ForEach(it =>
				{
					Console.WriteLine($"{it.LanguageId} - {it.LanguageName}");
				});
				int langSel = Convert.ToInt32(Console.ReadLine());
				while (langSel < 1 && langSel > programmingLanguages.Count)
				{
					Console.WriteLine($"Invalid option. Please try again");
					Console.WriteLine($"Choose a language that they know from the list below:");
					programmingLanguages.ForEach(it =>
					{
						Console.WriteLine($"{it.LanguageId} - {it.LanguageName}");
					});
					langSel = Convert.ToInt32((Console.ReadLine()));
				}
				EmployeeLanguage language = new EmployeeLanguage() { EmployeeId = empId, LanguageId = langSel };
				employeeLanguages.Add(language);
			}
			Console.WriteLine($"Saved!");
		}

		internal static List<string> GetDepartments(int numberOfEmployees)
		{
			if (departments.Count == 0)
			{
				return null;
			}

			var query = (from emp in employees join dep in departments on emp.DepartmentId equals dep.DepartmentId select dep.DepartmentName).Where(it => it.Count() >= numberOfEmployees).ToList();

			if (query.Count() == 0)
			{
				return null;
			}

			return query;
		}

		internal static List<Employee> GetEmployeeWorking()
		{
			var query = employees.Where(it => it.Status == Employee.EmployeeStatus.Working).ToList();

			if (query.Count() == 0)
			{
				return null;
			}
			return query;
		}

		internal static List<string> GetLanguages(int employeeId)
		{

			var query = (from lan in employeeLanguages join emp in employees on lan.EmployeeId equals emp.EmployeeId where emp.EmployeeId == employeeId join lang in programmingLanguages on lan.LanguageId equals lang.LanguageId select lang.LanguageName).ToList();

			if (query.Count() == 0)
			{
				return null;
			}
			return query;
		}

		internal static List<Employee> GetSeniorEmployee()
		{
			var query = (from lan1 in employeeLanguages join lan2 in employeeLanguages on lan1.EmployeeId equals lan2.EmployeeId join emp in employees on lan1.EmployeeId equals emp.EmployeeId where lan1.EmployeeId == lan2.EmployeeId select emp).ToList();

			return query;
		}

		internal static List<Employee> GetEmployeePaging(int pageIndex, int pageSize, string order)
		{
			switch (order)
			{
				case "ASC":
					var query = employees.Skip((pageIndex - 1) * pageSize).Take(pageSize).OrderBy(it => it.EmployeeName).ToList();
					return query;
				case "DESC":
					var queryDesc = employees.Skip((pageIndex - 1) * pageSize).Take(pageSize).OrderByDescending(it => it.EmployeeName).ToList();
					return queryDesc;
			}
			return null;
		}

		internal static void ListDepartments()
		{
			departments.ForEach(it =>
			{
				Console.WriteLine($"Department {it.DepartmentName}:");

				var query = (from emp in employees join dep in departments on emp.DepartmentId equals dep.DepartmentId where emp.DepartmentId == it.DepartmentId select emp).ToList();
			});
		}
	}
}