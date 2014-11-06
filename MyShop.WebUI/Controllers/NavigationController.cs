using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyShop.Domain.Abstract;

namespace MyShop.WebUI.Controllers
{
    public class NavigationController : Controller
    {
        private IProductRepository _repository;

        public NavigationController(IProductRepository repository)
        {
            _repository = repository;
        }

        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;
              IEnumerable<string> categories = _repository.Products
                .Select(x => x.Category.Name)
                .Distinct()
                .OrderBy(x => x);
              return PartialView(categories);
        }

    }
}
