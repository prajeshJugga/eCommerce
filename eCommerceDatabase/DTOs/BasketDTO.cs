using eCommerceDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceDatabase.DTOs
{
    public class BasketDTO
    {
        public BasketDTO()
        {
            
        }
        public BasketDTO(Basket basket)
        {
            Id = basket.Id;
            Items = basket.Items.Select(x => new BasketItemDTO(x)).ToList();
            CreatedDate = basket.CreatedDate;
            ModifiedDate = basket.ModifiedDate;
            Total = basket.Total;
        }

        public int Id { get; set; }
        public List<BasketItemDTO> Items { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public double Total { get; set; }
        bool ProgressedToOrder { get; set; }
    }
}
