using eCommerceDatabase.Models;

namespace eCommerceDatabase.DTOs
{
    public class CategoryDTO
    {
        public CategoryDTO() { }
        public CategoryDTO(Category category)
        {
            Id = category.Id;
            Name = category.Name;
            Description = category.Description;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
