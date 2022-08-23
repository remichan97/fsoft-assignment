namespace CSharpSOLIDExample.ISP.Violation
{
	/// <summary>
	/// suppose that the requirement is changed and require you that
	/// they want to read only data of loyal customers.
	/// What you will do, just add one method to this interface ?
	/// </summary>
	public interface ICustomerDatabase
	{
		bool AddCustomerDetails();

		// But now we are breaking something.
		// We are forcing loyal customer class to show their details from database.
		// The solution is to give this responsibility to another interface.
		bool ShowCustomerDetails(int customerId);
	}
}