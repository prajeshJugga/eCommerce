using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceDatabase.Models
{
    public class ProductOnSpecial
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int RequiredQuantity { get; set; } = 1;
        [Required]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        [Required]
        public int ActiveSpecialId { get; set; }
        public ActiveSpecial ActiveSpecial { get; set; }
    }
}
