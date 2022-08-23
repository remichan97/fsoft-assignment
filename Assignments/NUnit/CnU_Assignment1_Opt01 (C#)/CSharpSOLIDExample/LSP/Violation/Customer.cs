namespace CSharpSOLIDExample.LSP.Violation
{
	public abstract class Customer
	{
		public virtual string GetProjectDetails(int customerId)
		{
			return "Base Project";
		}

		public virtual string GetCustomerDetails(int customerId)
		{
			return "Base Customer";
		}
	}
}