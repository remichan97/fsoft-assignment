namespace CSharpSOLIDExample.LSP.Solution
{
	public class PotentialCustomer : Customer, IProject
	{
		public string GetCustomerProject(int customerId)
		{
			return "Potential Customer Project";
		}
	}
}