using System;
using System.Collections.Generic;

namespace CSharpSOLIDExample.LSP.Violation
{
	internal class Program
	{
		private void Test()
		{
			Console.WriteLine("Console Application");
			List<Customer> customerList = new List<Customer>();
			customerList.Add(new LoyalCustomer());
			customerList.Add(new PotentialCustomer());
			foreach (Customer customer in customerList)
			{
				customer.GetCustomerDetails(12);
			}

			// what issue here ?
			// for PotentialCustomer, you will get not implemented exception
			// and that is violating LSP.
			// Solution : Break the whole thing in 2 different interfaces,
			// 1. IProject
			// 2. ICustomer and implement according to customer type.
		}
	}
}