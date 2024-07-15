using eCommerceDatabase.DTOs;

namespace eCommerceApi.Services
{
    public interface IProductService
    {
        // To simplify the process, we will ignore page lengths for now (int page, int pageLength)
        List<ProductDTO> GetProducts();
    }
}
