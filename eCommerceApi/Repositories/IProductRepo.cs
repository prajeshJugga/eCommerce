using eCommerceDatabase.DTOs;
using eCommerceDatabase.Models;

namespace eCommerceApi.Repositories
{
    public interface IProductRepo
    {
        List<Product> GetProducts();
        Product? GetProductById(int productId);
        Product AddProduct(ProductDTO productDTO);
    }
}
