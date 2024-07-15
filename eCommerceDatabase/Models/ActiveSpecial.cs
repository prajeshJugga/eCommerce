using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceDatabase.Models
{
    /// <summary>
    /// A model to represent active specials, which has a one to many relationship with ProductOnSpecial
    /// All products on special will link to an active special, and the special will be calculated based on the Bundle Type
    /// </summary>
    public class ActiveSpecial
    {
        [Key]
        public int Id { get; set; }
        public List<ProductOnSpecial> ProductsOnSpecial { get; set; } = new List<ProductOnSpecial>();
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public double PercentageOff { get; set; }
        [Required]
        public int BundleTypeId { get; set; }
        public BundleType BundleType { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
    }
}
