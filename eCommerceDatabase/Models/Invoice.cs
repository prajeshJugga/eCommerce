using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceDatabase.Models
{
    public class Invoice
    {
        [Key]
        public int Id { get; set; }
        public List<InvoiceItem> Items { get; set; } = new List<InvoiceItem>();
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public double Total { get; set; }
    }
}
