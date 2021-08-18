using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Admin.Models
{
    public class ProductInputModel
    {
        public Guid ID { get; set; }
        public IFormFile Image { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Unit { get; set; }
        public decimal Quantity { get; set; }
        public List<string> Categories { get; set; }
    }
}
