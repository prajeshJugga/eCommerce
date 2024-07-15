using eCommerceDatabase.DTOs;
using System.ComponentModel.DataAnnotations;
namespace eCommerceDatabase.Models
{
    public class Brand
    {
        public Brand()
        {
        }
        public Brand(BrandDTO brand)
        {
            Id = brand.Id;
            Name = brand.Name;
            Description = brand.Description;
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}