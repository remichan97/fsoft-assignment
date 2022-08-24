namespace CSharpSOLIDExample.LSP.Solution
{
	public class PotentialCustomer : ICustomer, IProject
	{
		public string GetCustomerDetails(int customerId)
		{
			return "Potential Customer Detail";
		}

		public string GetCustomerProject(int customerId)
		{
			return "Potential Customer Project";
		}
	}
}