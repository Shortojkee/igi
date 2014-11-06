using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyShop.Domain.Entities;

namespace MyShop.WebUI.Models
{
    public class EditProductViewModel
    {
        public Product Product { get; set; }
        public string SelectedCategory { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}