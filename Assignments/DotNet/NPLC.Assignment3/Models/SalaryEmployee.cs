using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NPLC.Assignment3.Models
{
	internal class SalaryEmployee : Employee
	{
		public double Wage { get; set; }
		public double WorkingHours { get; set; }

		public SalaryEmployee(Employee employee) : base(employee) 
		{

		}

		public override string? ToString()
		{
			return base.ToString() + string.Format("{0, -10}{1, -20}", Wage, WorkingHours);
		}
	}
}