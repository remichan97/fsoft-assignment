using NPLC.Assignment3.Models;

namespace NPLC.Assignment3.Controller
{
    internal class DepartmentManage
    {
        private static Department? department;

        private static List<Department> departmentList = new List<Department>();

        public DepartmentManage()
        {
            department = new Department();
        }

        internal static void Menu()
        {
            Console.WriteLine($"App menu");
            Console.WriteLine($"1. Add new Department");
            Console.WriteLine($"2. Add new Employee");
            Console.WriteLine($"3. View all Employee");
            Console.WriteLine($"4. Classifies Employee");
            Console.WriteLine($"5. Search for Employee");
            Console.WriteLine($"6. Report");
            Console.WriteLine($"7. Exit");
            Console.Write("Your choice: ");
        }

        internal static void AddDepartment()
        {
            Console.WriteLine($"Enter a department name to add");
            string departmentName = Console.ReadLine();

            if (string.IsNullOrEmpty(departmentName))
            {
                throw new ArgumentNullException("Department name cannot be empty. Aborted.");
            }
            Department department = new Department { DepartmentName = departmentName };

            departmentList.Add(department);

            Console.WriteLine($"Saved!");
        }

        internal static int SelectDepartment()
        {
            if (departmentList.Count() == 0)
            {
                Console.WriteLine($"No department present. Please add a department before adding an employee");
                return -1;
            }

            Console.WriteLine($"Which Department you wishes to add Employee in?");
            departmentList.ForEach(it => Console.WriteLine($"{departmentList.IndexOf(it)}: {departmentList.ToString()}")
            );
            int select = Convert.ToInt32(Console.ReadLine());
            while (select < 0 && select > departmentList.Count)
            {
                Console.WriteLine($"Invalid choice. Please enter another choice!");
                select = Convert.ToInt32(Console.ReadLine());
            }
            return select;
        }

        internal static void AddEmployeeMenu()
        {
            Console.WriteLine($"What kind of Employee you wishes to add:");
            Console.WriteLine($"1. Hourly Employee");
            Console.WriteLine($"2. Salaried Employee");
            Console.WriteLine($"Your choice: ");
        }

        internal static Employee InputEmployeeInfo()
        {
            Console.WriteLine($"Employee First Name: ");
            string empFirstName = Console.ReadLine()!;
            Console.WriteLine($"Employee Last Name: ");
            string empLastName = Console.ReadLine()!;
            Console.WriteLine($"Employee Birth date: ");
            DateTime empBirthDate = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine($"Employee Phone Number: ");
            string empPhoneNumber = Console.ReadLine()!;
            Console.WriteLine($"Employee Email address: ");
            string empEmail = Console.ReadLine()!;
            Employee employee = new Employee() { FirstName = empFirstName, LastName = empLastName, BirthDay = empBirthDate, PhoneNumber = empPhoneNumber, Email = empEmail };
            return employee;
        }

        internal static void AddSalariedEmployee(int deptChoice)
        {
            Employee employee = InputEmployeeInfo();
            Console.WriteLine($"Wage: ");
            double wage = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"Working hour: ");
            double workingHour = Convert.ToDouble(Console.ReadLine());
            SalaryEmployee salaryEmployee = new SalaryEmployee(employee) { Wage = wage, WorkingHours = workingHour };
            departmentList[deptChoice]!.Employees!.Add(salaryEmployee);
        }

        internal static void AddHourlyEmployee(int deptChoice)
        {
            Employee employee = InputEmployeeInfo();
            Console.WriteLine($"Commission Rate: ");
            double commissionRate = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"Gross Rate: ");
            double grossRate = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"Basic Salary: ");
            double basicSalary = Convert.ToDouble(Console.ReadLine());
            HourlyEmployee hourlyEmployee = new HourlyEmployee(employee) { CommisionRate = commissionRate, GrossRate = grossRate, BasicSalary = basicSalary };
            departmentList[deptChoice]!.Employees!.Add(hourlyEmployee);
        }

        internal static void DisplayEmployee()
        {
            if (departmentList.Count == 0)
            {
                Console.WriteLine($"No department present. Please add a department before any employee can be displayed");
                return;
            }
            departmentList.ForEach(it =>
            {
                Console.WriteLine($"Department: {it.DepartmentName}");
                it.Employees!.ForEach(x => x.ToString());
            });
        }

        internal static void Search(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
            {
                DisplayEmployee();
                return;
            }

            var containDepartment = departmentList.Where(it => it.DepartmentName.Equals(keyword));

            if (containDepartment.Count() > 1)
            {
                foreach (var item in containDepartment)
                {
                    Console.WriteLine($"{item.DepartmentName}");
                    item.Employees.ForEach(it => it.ToString());
                }
                return;
            }
            else
            {
                return;
            }
        }

        internal static void Count()
        {
            var sortedList = from employee in departmentList
                             group employee by employee.DepartmentName into departmentGroup
                             select new
                             {
                                 Department = departmentGroup.Key,
                                 Count = departmentGroup.Count(),
                             };
            foreach (var src in sortedList)
            {
                Console.WriteLine(string.Format("{0} - {1}", src.Department, src.Count));
            }
        }

        internal static void ClassifiesEmployee()
        {
            var hourlyEmployee = department.GetEmployees<HourlyEmployee>();
            Console.WriteLine($"==============Hourly Employee============");

            hourlyEmployee.ForEach(it =>
            {
                Console.WriteLine(it.ToString());
            });

            var salariedEmployee = department.GetEmployees<SalaryEmployee>();
            Console.WriteLine("==============Salaries Employee==============");

            salariedEmployee.ForEach(it =>
            {
                Console.WriteLine($"{it.ToString()}");
            });
        }
    }
}