using eCommerceDatabase.DTOs;
using System.ComponentModel.DataAnnotations;

namespace eCommerceDatabase.Models
{
    public class Category
    {
        public Category()
        {
        }
        public Category(CategoryDTO category)
        {
            Id = category.Id;
            Name = category.Name;
            Description = category.Description;
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}