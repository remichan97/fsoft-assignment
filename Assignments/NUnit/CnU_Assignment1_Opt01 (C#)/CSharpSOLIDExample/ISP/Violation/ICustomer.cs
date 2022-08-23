namespace CSharpSOLIDExample.ISP.Violation
{
	/// <summary>
	/// suppose that there is one database for storing data of all types
	/// of customers (potential and loyal)
	/// what is the best approach for our interface ?
	/// And all types of customer class will inherit this interface for saving data.
	/// </summary>
	public interface ICustomer
	{
		bool AddCustomerDetails();
	}
}