namespace CSharpSOLIDExample.ISP.Solution
{
	internal interface ILoyalCustomer : ICustomer
	{
		bool ShowCustomerDetails(int customerId);
	}
}