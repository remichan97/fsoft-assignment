namespace CSharpSOLIDExample.LSP.Violation
{
	public class LoyalCustomer : Customer
	{
		public override string GetProjectDetails(int customerId)
		{
			return "Child Project";
		}

		public override string GetCustomerDetails(int customerId)
		{
			return "Child Customer";
		}
	}
}