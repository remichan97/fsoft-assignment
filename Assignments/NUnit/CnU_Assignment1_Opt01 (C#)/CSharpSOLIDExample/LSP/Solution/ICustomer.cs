namespace CSharpSOLIDExample.LSP.Solution
{
	public interface ICustomer : IProject
	{
		string GetCustomerDetails(int customerId);
	}
}