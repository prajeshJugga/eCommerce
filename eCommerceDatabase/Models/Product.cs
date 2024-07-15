using eCommerceDatabase.DTOs;
using System.ComponentModel.DataAnnotations;

namespace eCommerceDatabase.Models
{
    public class Product
    {
        public Product()
        {
        }
        public Product(ProductDTO product)
        {
            Id = product.Id;
            Name = product.Name;
            Description = product.Description;
            Category = new Category(product.Category);
            Brand = new Brand(product.Brand);
            Price = product.Price;
            CreatedDate = product.CreatedDate;
            ModifiedDate = product.ModifiedDate;
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public double Price { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
