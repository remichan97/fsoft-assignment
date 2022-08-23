using CSharpSOLIDExample.OCP.Solution;

namespace CSharpSOLIDExample.SRP.Solution
{
	public class CustomerManage
	{
		public bool InsertIntoCustomerTable(Customer customer)
		{
			// Insert into customer table.
			return true;
		}

		/// <summary>
		/// Method to generate report
		/// </summary>
		/// <param name="customer">Customer object</param>
		public void GenerateReport(Customer customer)
		{
			// Report generation with customer data.
		}
	}
}