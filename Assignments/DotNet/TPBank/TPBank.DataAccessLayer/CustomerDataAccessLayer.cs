using TPBank.Entities.Models;

namespace TPBank.DataAccessLayer
{
	public class CustomerDataAccessLayer : ICustomerDataAccessLayer
	{
		private static List<Customer>? customers;

        public CustomerDataAccessLayer()
        {
			customers = new List<Customer>();
		}

		public Guid AddCustomer(Customer customer)
		{
			customers.Add(customer);
			return customer.CustomerId;
		}

		public bool DeleteCustomer(Guid customerId)
		{
			var query = customers.Where(it => it.CustomerId.Equals(customerId)).FirstOrDefault();
			return customers.Remove(query);
		}

		public Customer GetCustomerByUsername(string username)
		{
			return customers.FirstOrDefault(it => it.Username.Equals(username));
		}

		public List<Customer> GetCustomers()
		{
			return customers;
		}

		public List<Customer> GetCustomersByCondition(Func<Customer, bool> predicate)
		{
			return customers.Where(predicate).ToList();
		}

		public bool UpdateCustomer(Customer customer)
		{
			var query = customers.Where(it => it.Username.Equals(customer.Username)).FirstOrDefault();
			if (query is null)
			{
				return false;
			}

			var index = customers.IndexOf(query);

			customers[index] = customer;
			return true;
		}
	}
}