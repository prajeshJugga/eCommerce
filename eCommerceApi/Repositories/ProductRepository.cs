using eCommerceApi.Exceptions;
using eCommerceDatabase.DTOs;
using eCommerceDatabase.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eCommerceApi.Repositories
{
    public class ProductRepository : IProductRepo
    {
        private readonly ECommerceContext _context;
        private readonly ILogger<ProductRepository> _logger;
        public ProductRepository(ECommerceContext dbContext, ILogger<ProductRepository> logger)
        {
            _context = dbContext;
            _logger = logger;
        }

        public List<Product> GetProducts()
        {
            try
            {
                return _context.Products.ToList();
            }
            catch (ArgumentNullException)
            {
                _logger.LogError("Error retrieving products, no products exist ...");
                return new List<Product>();
            }
        }

        public Product AddProduct(ProductDTO productDTO)
        {
            throw new NotImplementedException();
        }

        public Product? GetProductById(int productId)
        {
            Product? product = _context.Products.SingleOrDefault(i => i.Id == productId);
            if (product == null)
            {
                throw new ProductNotFoundException();
            }
            return product;
        }
    }
}
