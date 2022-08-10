using System.ComponentModel.DataAnnotations;

namespace NPLC.Assignment3.Models
{
	internal class Employee
	{
		public Guid Ssn { get; set; } = Guid.NewGuid();
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
		private DateTime birthDay;

		public DateTime BirthDay
		{
			get
			{
				return this.birthDay;
			}
			set
			{
				if (this.birthDay >= DateTime.Now.Date)
				{
					throw new ArgumentException("Birthday cannot be in the future nor in current date");
				}
			}
		}

		private string? phoneNumber;
		[Phone]
		public string? PhoneNumber
		{
			get
			{
				return this.phoneNumber;
			}
			set
			{
				if (this.phoneNumber!.Length < 7)
				{
					throw new ArgumentException("Phone number must be at least 7 characters");
				}
			}
		}
		[EmailAddress]
		public string? Email { get; set; }
		
		public Employee()
		{
			
		}

		protected Employee(Employee employee)
		{
			this.Ssn = employee.Ssn;
			this.FirstName = employee.FirstName;
			this.LastName = employee.LastName;
			this.BirthDay = employee.BirthDay;
			this.PhoneNumber = employee.PhoneNumber;
			this.Email = employee.Email;
		}

		public override string? ToString()
		{
			return string.Format("{0, -10}{1, -20}{2, -30}{3, -40}{4, -50}{5, -60}", Ssn,FirstName, LastName, BirthDay, PhoneNumber, Email);
		}
	}
}