using eCommerceApi.Repositories;
using eCommerceDatabase.DTOs;
using eCommerceDatabase.Models;

namespace eCommerceApi.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ILogger<CustomerService> _logger;
        private readonly ICustomerRepo _repo;

        public CustomerService(ILogger<CustomerService> logger, ICustomerRepo repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public CustomerDTO GetCustomerById(int customerId)
        {
            Customer customer = _repo.GetCustomerById(customerId);
            return new CustomerDTO(customer);
        }
 
    }
}
