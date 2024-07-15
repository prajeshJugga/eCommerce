using eCommerceDatabase.DTOs;
using eCommerceDatabase.Models;

namespace eCommerceApi.Repositories.Mocks
{
    public class MockProductRepo : IProductRepo
    {
        private static Dictionary<string, Category> _categories = new Dictionary<string, Category>
        {
            { "Monitors", new Category { Id = 1, Name = "Monitors", Description = "Computer Monitors" } },
            { "Laptops", new Category { Id = 2, Name = "Laptops", Description = "Laptops" } },
            { "Desktop PCs", new Category { Id = 3, Name = "Desktop PCs", Description = "Desktop PCs" } },
            { "Mice", new Category { Id = 3, Name = "Mice", Description = "Mice" } },
        };

        private static Dictionary<string, Brand> _brands = new Dictionary<string, Brand>
        {
            { "LG", new Brand { Id = 1, Name = "LG" } },
            { "Samsung", new Brand { Id = 2, Name = "Samsung" } },
            { "DELL", new Brand { Id = 3, Name = "DELL" } },
            { "MSi", new Brand { Id = 4, Name = "MSi" } },
            { "Logitech", new Brand { Id = 5, Name = "Logitech" } },
        };

        private List<Product> _products = new List<Product>
        {
            new Product
            {
                Id = 1,
                Name = "LG LCD TV Monitor 20'",
                Description = "LG LCD TV Monitor 20'",
                Category = _categories["Monitors"],
                Brand = _brands["LG"],
                Price = 1299,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
            },
            new Product
            {
                Id = 2,
                Name = "DELL Gaming Laptop",
                Description = "DELL Gaming Laptop, Intel i7, 32GB DDR5 RAM, 512GB SSD, 4GB Nvidia GEForce",
                Category = _categories["Laptops"],
                Brand = _brands["DELL"],
                Price = 9999,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
            },
            new Product
            {
                Id = 3,
                Name = "Logitech Mouse",
                Description = "Logitech RGB Gaming Mouse",
                Category = _categories["Mice"],
                Brand = _brands["Logitech"],
                Price = 899,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
            }
        };

        public Product AddProduct(ProductDTO productDTO)
        {
            throw new NotImplementedException();
        }

        public Product? GetProductById(int productId)
        {
            throw new NotImplementedException();
        }

        //public Task<List<Product>> GetProducts()
        public List<Product> GetProducts()
        {
            //return Task.FromResult(_products);
            return _products;
        }
    }
}
