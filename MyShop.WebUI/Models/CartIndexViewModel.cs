using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyShop.Domain.Entities;

namespace MyShop.WebUI.Models
{
    public class CartIndexViewModel
    {
        public ShoppingCart Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}