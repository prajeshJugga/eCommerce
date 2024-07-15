using eCommerceDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceDatabase.DTOs
{
    public class BrandDTO
    {
        public BrandDTO()
        {
            
        }
        public BrandDTO(Brand brand)
        {
            Id = brand.Id;
            Name = brand.Name;
            Description = brand.Description;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
