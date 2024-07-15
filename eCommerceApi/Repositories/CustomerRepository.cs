using eCommerceApi.Exceptions;
using eCommerceDatabase.DTOs;
using eCommerceDatabase.Models;

namespace eCommerceApi.Repositories
{
    public class CustomerRepository : ICustomerRepo
    {
        private readonly ECommerceContext _context;
        private readonly ILogger<CustomerRepository> _logger;
        public CustomerRepository(ECommerceContext dbContext, 
            ILogger<CustomerRepository> logger)
        {
            _context = dbContext;
            _logger = logger;
        }

        public List<Customer> GetAll()
        {
            return _context.Customers.ToList();
        }

        public Customer? GetCustomerById(int customerId)
        {
            Customer customer = _context.Customers.SingleOrDefault(x => x.Id == customerId);
            return customer;
        }
    }
}
