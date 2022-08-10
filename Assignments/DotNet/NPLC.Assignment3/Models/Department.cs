namespace NPLC.Assignment3.Models
{
	internal class Department
	{
		public string? DepartmentName { get; set; }

		public List<Employee>? Employees { get; set; }

		public int CountOf<T>() where T : class
		{
			return Employees!.Where(x => x is T).Count();
		} 

		public List<T> GetEmployees<T>() where T : class
		{
			return Employees.Where(x => x is T).Select(it => it as T).ToList();
		}
	}
}