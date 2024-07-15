using System.ComponentModel.DataAnnotations;

namespace eCommerceDatabase.Models
{
    public class Basket
    {
        [Key]
        public int Id { get; set; }
        public List<BasketItem> Items { get; set; } = new List<BasketItem>();
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool ProgressedToOrder { get; set; }
        public double Total { get; set; }
    }
}
