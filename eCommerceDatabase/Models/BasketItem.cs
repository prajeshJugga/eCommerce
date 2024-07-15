using eCommerceDatabase.DTOs;
using System.ComponentModel.DataAnnotations;

namespace eCommerceDatabase.Models
{
    public class BasketItem
    {
        public BasketItem()
        {
            
        }
        public BasketItem(BasketItemDTO basketItemDTO) 
        { 
            //Product = new Product(basketItemDTO.Product);
            ProductId = basketItemDTO.ProductId;
            Quantity = basketItemDTO.Quantity;
            Price = basketItemDTO.Price;
            CreatedDate = basketItemDTO.CreatedDate;
            ModifiedDate = basketItemDTO.ModifiedDate;
            BasketId = basketItemDTO.BasketId;
        }
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int BasketId { get; set; }
        public Basket Basket { get; set; }
    }
}
