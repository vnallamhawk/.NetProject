using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingApplication.Models
{
    public class Customer
    {
        public int customerId { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string mobile { get; set; }
        public string email { get; set; }

        public string address { get; set; }

        public string city { get; set; }

        public virtual ICollection<Order> Orders { get; set; }


    }
}