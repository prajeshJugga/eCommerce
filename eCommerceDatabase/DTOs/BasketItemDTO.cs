using eCommerceDatabase.Models;

namespace eCommerceDatabase.DTOs
{
    public class BasketItemDTO
    {
        public BasketItemDTO()
        {
            
        }
        public BasketItemDTO(BasketItem basketItem)
        {
            Id = basketItem.Id;
            Quantity = basketItem.Quantity;
            Price = basketItem.Price;
            CreatedDate = basketItem.CreatedDate;
            ModifiedDate = basketItem.ModifiedDate;
            ProductId = basketItem.ProductId;
            BasketId = basketItem.BasketId;
            //Product = new ProductDTO(basketItem.Product);
        }

        public int Id { get; set; }
        public int ProductId { get; set; }
        //public ProductDTO Product { get; set; } = null!;
        public int Quantity { get; set; }
        public double Price { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int BasketId { get; internal set; }
    }
}
