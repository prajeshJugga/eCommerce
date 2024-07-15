using eCommerceDatabase.DTOs;

namespace eCommerceApi.Services
{
    public interface ICustomerService
    {
        // To simplify the process, we will ignore page lengths for now (int page, int pageLength)
        CustomerDTO GetCustomerById(int customerId);
    }
}
