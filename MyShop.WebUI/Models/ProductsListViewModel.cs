using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyShop.Domain.Entities;

namespace MyShop.WebUI.Models
{
    public class ProductsListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PageNavigation PageNavigation { get; set; }
        public string CurrentCategory { get; set; }
    }
}