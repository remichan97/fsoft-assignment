namespace NPLC.Assignment7.Models
{
	public class Department
	{
		public int DepartmentId { get; set; }
		private string? departmentName;
		public string DepartmentName
		{
			get
			{
				return this.departmentName;
			}
			set
			{
				if (string.IsNullOrWhiteSpace(this.departmentName)) throw new ArgumentNullException("Department name cannot be empty. Aborted.");
			}
		}
	}
}