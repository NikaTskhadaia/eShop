using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Web.Models
{
    public class CartModel
    {
        public Guid UserId { get; set; }
        public Dictionary<Guid, int> Products { get; set; }

    }
}
