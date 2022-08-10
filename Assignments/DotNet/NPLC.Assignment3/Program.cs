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
                        int deptChoice = DepartmentManage.SelectDepartment();
                        if (deptChoice == -1) break;
                        DepartmentManage.AddEmployeeMenu();
                        int choice = Convert.ToInt32(Console.ReadLine());
                        switch (choice)
                        {
                            case 1:
                                DepartmentManage.AddHourlyEmployee(deptChoice);
                                break;

                            case 2:
                                DepartmentManage.AddSalariedEmployee(deptChoice);
                                break;
                        }
                        break;

                    case 2:
                        DepartmentManage.DisplayEmployee();
                        break;

                    case 3:
                        DepartmentManage.ClassifiesEmployee();
                        break;

                    case 4:
                        Console.WriteLine($"Enter a keyword to search: ");
                        string keyword = Console.ReadLine()!;
                        DepartmentManage.Search(keyword);
                        break;

                    case 5:
                        DepartmentManage.Count();
                        break;

                    case 6:
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}