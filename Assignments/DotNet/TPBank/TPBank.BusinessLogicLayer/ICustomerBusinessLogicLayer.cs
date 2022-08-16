using TPBank.Entities;
using TPBank.Entities.DTO;
using TPBank.Entities.Models;

namespace TPBank.BusinessLogicLayer
{
    public interface ICustomerBusinessLogicLayer
    {
        /// <summary>
        /// Find and return a list of customer
        /// </summary>
        /// <returns></returns>
        ResponseResult<List<Customer>> GetCustomer();

        /// <summary>
        /// Get a list of customers that match a condition specified as a predicate
        /// </summary>
        /// <param name="predicate">The predicate act as a query to look into the list of customer</param>
        /// <returns></returns>
		ResponseResult<List<Customer>> GetCustomersByCondition(Func<Customer, bool> predicate);

        /// <summary>
        /// Add a customer to the list
        /// </summary>
        /// <param name="customer">The customer info to add</param>
        /// <returns></returns>
		ResponseResult<Customer> AddCustomer(AddCustomerDTO customer);

        /// <summary>
        /// Search a customer data by username
        /// </summary>
        /// <param name="username">the username to search for</param>
        /// <returns></returns>
        ResponseResult<Customer> GetCustomerByUsername(string username);

        /// <summary>
        /// Update a customer info
        /// </summary>
        /// <param name="customer">The customer info to update</param>
        /// <returns></returns>
		bool UpdateCustomer(Customer customer);

        /// <summary>
        /// Delete a customer information
        /// </summary>
        /// <param name="customer">The customer to delete</param>
        /// <returns></returns>
		bool DeleteCustomer(Guid customerId);
    }
}