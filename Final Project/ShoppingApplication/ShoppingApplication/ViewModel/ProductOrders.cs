using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShoppingApplication.Models;

namespace ShoppingApplication.ViewModel
{
    public class ProductOrders
    {
        public IEnumerable<Order> Orders { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
    }
}