namespace CSharpSOLIDExample.SRP.Solution
{
	public class Customers
	{
		public int Customer_Id { get; set; }
		public string Customer_Name { get; set; }

		public bool InsertIntoCustomerTable(Customers customer)
		{
			// Insert into customer table.
			return true;
		}
	}
}