using eCommerceApi.Exceptions;
using eCommerceDatabase.Models;

namespace eCommerceApi.Repositories.Mocks
{
    public class MockCustomerRepo : ICustomerRepo
    {
        private readonly ILogger<MockCustomerRepo> _logger;
        public MockCustomerRepo(ILogger<MockCustomerRepo> logger)
        {
            _logger = logger;
        }
        public List<Customer> GetAll()
        {
            _logger.LogInformation("Retrieving all Customer records ...");
            return new List<Customer>
            {
                new Customer
                {
                    Id = 1,
                    Name = "Test",
                    Surname = "Case",
                    Password = "HASH13123ADDDDSDAEDDDDD",
                    Phone = "0123456789",
                    Username = "Test",
                    Address = "Test",
                    Email = "Test@test.com",
                },
                new Customer
                {
                    Id = 2,
                    Name = "Test2",
                    Surname = "Case2",
                    Password = "HASH13123ADDDDSDAEDDDDD",
                    Phone = "0123456780",
                    Username = "Test2",
                    Address = "Test2",
                    Email = "Test2@test.com",
                }
            };
        }

        public Customer GetCustomerById(int customerId)
        {
            try
            {
                List<Customer> allCustomers = GetAll();
                _logger.LogInformation(string.Format("Retrieving Customer record with Id: {0} ...", customerId));
                Customer customer = allCustomers.SingleOrDefault(x => x.Id == customerId);
                if (customer == null)
                {
                    throw new CustomerNotFoundException(string.Format("Customer with Id: {0} does not exist", customerId));
                }
                return customer;
            }
            catch (CustomerNotFoundException ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError("An unexpected error occured when retrieving customer records ...");
                throw;
            }
        }


    }
}
