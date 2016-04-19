using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingApplication.Models
{
    public class OrderStatus
    {

        public int OrderStatusId { get; set; }

        public string status { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}