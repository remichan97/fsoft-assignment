namespace CSharpSOLIDExample.LSP.Solution
{
	public abstract class Customer : ICustomer
	{
		public virtual string GetCustomerDetails(int customerId)
		{
			return "Base Customer";
		}
	}
}