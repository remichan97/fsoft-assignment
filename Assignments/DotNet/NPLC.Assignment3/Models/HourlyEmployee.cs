namespace NPLC.Assignment3.Models
{
	internal class HourlyEmployee : Employee
	{
		public double CommisionRate { get; set; }
		public double GrossRate { get; set; }
		public double BasicSalary { get; set; }

		public HourlyEmployee(Employee employee) : base (employee)
		{
			
		}

		public override string? ToString()
		{
			return base.ToString() + string.Format("{0, -10}{1, -20}{2, -30}", CommisionRate, GrossRate, BasicSalary);
		}
	}
}