using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceDatabase.Models
{
    public enum Bundle
    {
        BUNDLE,
        CATEGORY_COMBO
    }
    public class BundleType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        // percentage=10,type=bundle
    }
}
