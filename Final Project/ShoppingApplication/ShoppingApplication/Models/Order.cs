using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingApplication.Models
{
    public class Order
    {
        public int orderId { get; set; }

        //public string status { get; set; }

        public DateTime orderDate { get; set; }

        public int Custid {get; set;}

        public int OStatusId { get; set; }

        public virtual Customer customer { get; set; }

        public virtual OrderStatus Ostatus { get; set; }

        // This property will hold all available states for selection
        //public IEnumerable<SelectListItem> Status { get; set; }
        public virtual ICollection<Product> Products { get; set; }

 
    }
}