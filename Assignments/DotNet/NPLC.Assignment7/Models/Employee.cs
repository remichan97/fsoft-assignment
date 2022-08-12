namespace NPLC.Assignment7.Models
{
	public class Employee
    {
        public enum EmployeeStatus 
        {
            Working = 0,
            Terminated = 1
        }

		public int EmployeeId { get; set; }
        public string? EmployeeName { get; set; }
        public int Age { get; set; }
        public string? Address { get; set; }
        public DateTime HiredDate { get; set; }
		public EmployeeStatus Status { get; set; } = EmployeeStatus.Working;
        public int DepartmentId { get; set; }

		public override string? ToString()
		{
			return EmployeeName + " " + Age + " " + Address + " " + HiredDate + " " + Status;
		}
	}
}