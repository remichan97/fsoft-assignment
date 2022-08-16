using TPBank.Entities.Models;

namespace TPBank.DataAccessLayer
{
    public interface ICustomerDataAccessLayer
    {
        Customer GetCustomerByUsername(string username);

        List<Customer> GetCustomers();

        List<Customer> GetCustomersByCondition(Func<Customer, bool> predicate);

        Guid AddCustomer(Customer customer);

        bool UpdateCustomer(Customer customer);

        bool DeleteCustomer(Guid customerId);
    }
}