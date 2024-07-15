using eCommerceApi.Repositories;
using eCommerceDatabase.DTOs;
using eCommerceDatabase.Models;

namespace eCommerceApi.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepo repo;
        public ProductService(IProductRepo productRepo)
        {
            repo = productRepo;
        }

        // TODO: Add some exception and logging to make this more close to production code
        public List<ProductDTO> GetProducts()
        {
            List<Product> products = repo.GetProducts();
            return products.Select(product => new ProductDTO(product)).ToList();
        }
    }
}
