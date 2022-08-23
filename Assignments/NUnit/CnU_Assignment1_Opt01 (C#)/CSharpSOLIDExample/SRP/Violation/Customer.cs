namespace CSharpSOLIDExample.SRP.Violation
{
	internal class Customer
	{
		public int Customer_Id { get; set; }
		public string Customer_Name { get; set; }

		// ‘Customer’ class is taking 2 responsibilities,
		// one is to take responsibility of customer database operation and
		// another one is to generate customer report.
		// It violates SRP

		/// <summary>
		/// This method is used to insert a customer into customer table
		/// </summary>
		/// <param name="customer">Customer object</param>
		/// <returns>Successfully inserted or not</returns>
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