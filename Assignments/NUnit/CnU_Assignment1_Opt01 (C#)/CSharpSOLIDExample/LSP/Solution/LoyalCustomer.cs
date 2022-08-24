namespace CSharpSOLIDExample.LSP.Solution
{
	public class LoyalCustomer : ICustomer
	{
		public string GetCustomerDetails(int customerId)
		{
			return "Loyal Customer Detail";
		}
	}
}