using TPBank.DataAccessLayer;
using TPBank.Entities;
using TPBank.Entities.DTO;
using TPBank.Entities.Models;

namespace TPBank.BusinessLogicLayer
{
	public class CustomerBusinessLogicLayer : ICustomerBusinessLogicLayer
	{
		private readonly ICustomerDataAccessLayer customerDataAccessLayer;

		public CustomerBusinessLogicLayer()
		{
			this.customerDataAccessLayer = new CustomerDataAccessLayer();
		}

		public ResponseResult<Customer> AddCustomer(AddCustomerDTO customer)
		{
			if (!customer.CustomerCode.IsCustomerCodeValid())
			{
				return new ResponseResult<Customer>("Customer Code must not negative or smaller than 1");
			}
			if (!customer.CustomerName.IsCustomerNameValid())
			{
				return new ResponseResult<Customer>("Customer Name must not empty and must have less than 40 characters");
			}
			if (!customer.Username.IsUsernameNull())
			{
				return new ResponseResult<Customer>("Username must not be empty");
			}
			if (!customer.Password.IsPasswordValid())
			{
				return new ResponseResult<Customer>("Password must have at least 6 characters, and must have an uppercase, a lowercase and a numeric character.");
			}
			try
			{
				Customer customerAdd = new Customer() { CustomerCode = customer.CustomerCode, CustomerName = customer.CustomerName, Address = customer.Address, City = customer.City, Landmark = customer.Landmark, Country = customer.Country, PhoneNumber = customer.PhoneNumber, Username = customer.Username, Password = customer.Password };



				var customerId = customerDataAccessLayer.AddCustomer(customerAdd);
				return new ResponseResult<Customer>() { Result = customerAdd };
			}
			catch (Exception ex)
			{
				return new ResponseResult<Customer>(ex.Message);
			}
		}

		public bool DeleteCustomer(Guid customerId)
		{
			return customerDataAccessLayer.DeleteCustomer(customerId);
		}

		public ResponseResult<Customer> GetCustomerByUsername(string username)
		{
			try
			{
				return new ResponseResult<Customer>() { Result = customerDataAccessLayer.GetCustomerByUsername(username) };
			}
			catch (Exception ex)
			{
				return new ResponseResult<Customer>(ex.Message);
			}
		}

		public ResponseResult<List<Customer>> GetCustomer()
		{
			try
			{
				return new ResponseResult<List<Customer>>() { Result = customerDataAccessLayer.GetCustomers() };
			}
			catch (Exception ex)
			{
				return new ResponseResult<List<Customer>>(ex.Message);
			}
		}

		public ResponseResult<List<Customer>> GetCustomersByCondition(Func<Customer, bool> predicate)
		{
			try
			{
				return new ResponseResult<List<Customer>>() { Result = customerDataAccessLayer.GetCustomersByCondition(predicate) };
			}
			catch (Exception ex)
			{
				return new ResponseResult<List<Customer>>(ex.Message);
			}
		}

		public bool UpdateCustomer(Customer customer)
		{
			if(!customer.Password.IsPasswordValid()) return false;
			return customerDataAccessLayer.UpdateCustomer(customer);
		}

		public Customer CheckUnique(Customer customer)
		{
			return customerDataAccessLayer.CheckUnique(customer);
		}
	}
}