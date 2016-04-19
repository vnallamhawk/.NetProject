using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingApplication.Models
{
    public class Product
    {
        public int productId { get; set; }
        public string name { get; set; }
        public string type { get; set; }

        public int price { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

    }
}