using System;

namespace CSharpSOLIDExample.LSP.Violation
{
	public class PotentialCustomer : Customer
	{
		public override string GetProjectDetails(int customerId)
		{
			return "Child Project";
		}

		public override string GetCustomerDetails(int customerId)
		{
			throw new NotImplementedException();
		}
	}
}