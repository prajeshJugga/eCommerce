using eCommerceDatabase.Models;
using eCommerceDatabase.DTOs;

namespace eCommerceDatabase.DTOs
{
    public class ProductDTO
    {
        public ProductDTO()
        {
            
        }

        public ProductDTO(Product product)
        {
            Id = product.Id;
            Name = product.Name;
            Description = product.Description;
            CategoryId = product.CategoryId;
            BrandId = product.BrandId;
            Price = product.Price;
            CreatedDate = product.CreatedDate;
            ModifiedDate = product.ModifiedDate;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public CategoryDTO Category { get; set; } = null!;
        public int BrandId { get; set; }
        public BrandDTO Brand { get; set; } = null!;
        public double Price { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}