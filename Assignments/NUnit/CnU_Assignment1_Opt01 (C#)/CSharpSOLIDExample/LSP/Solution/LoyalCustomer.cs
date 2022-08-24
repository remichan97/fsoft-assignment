namespace CSharpSOLIDExample.LSP.Solution
{
	public class LoyalCustomer : Customer, IProject
	{
		public override string GetCustomerDetails(int customerId)
		{
			return "Loyal Customer Detail";
		}

		public string GetCustomerProject(int customerId)
		{
			return "Loyal Project";
		}
	}
}