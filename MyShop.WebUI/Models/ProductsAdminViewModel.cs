using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyShop.Domain.Entities;

namespace MyShop.WebUI.Models
{
    public class ProductsAdminViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}