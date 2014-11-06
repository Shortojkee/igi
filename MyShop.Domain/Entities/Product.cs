using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MyShop.Domain.Entities
{
    public class Product
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter a product name")]
        public string Name { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a positive price")]
        public Nullable<int> Price { get; set; }

        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Please enter a description")]
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public string ImagePath { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string ImageMimeType { get; set; }
        public string BrandName { get; set; }
        public string OS { get; set; }
        public Nullable<decimal> ScreenSize { get; set; }
        public string DisplayResolution { get; set; }
        public string DisplayRatio { get; set; }
        public string TouchScreenType { get; set; }
        public Nullable<int> Weight { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<OrderLine> OrderLines { get; set; }
    }
}