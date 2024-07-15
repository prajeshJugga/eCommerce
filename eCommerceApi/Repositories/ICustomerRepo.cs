using eCommerceDatabase.DTOs;
using eCommerceDatabase.Models;

namespace eCommerceApi.Repositories
{
    public interface ICustomerRepo
    {
        Customer? GetCustomerById(int customerId);
        //Task<Customer> AddCustomer(CustomerDTO customer);
        List<Customer> GetAll();
    }
}
