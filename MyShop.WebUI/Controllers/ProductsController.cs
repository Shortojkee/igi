using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyShop.Domain.Abstract;
using MyShop.Domain.Entities;
using MyShop.WebUI.Models;

namespace MyShop.WebUI.Controllers
{
    public class ProductsController : Controller
    {
        private IProductRepository _repository;
        public int PageSize = 4;

        public ProductsController(IProductRepository repository)
        {
            _repository = repository;
        }

        //public ViewResult List(string category, int page = 1)
        //{
        //    ProductsListViewModel viewModel = new ProductsListViewModel();
        //    viewModel.CurrentCategory = category;
        //    viewModel.Products = _repository.Products
        //        .Where(p => category == null || p.Category.Name == category)
        //        .OrderBy(p => p.Id)
        //        .Skip((page - 1)*PageSize)
        //        .Take(PageSize);
        //    viewModel.PageNavigation = new PageNavigation
        //    {
        //        CurrentPage = page,
        //        ItemsPerPage = PageSize,
        //        TotalItems = category == null
        //            ? _repository.Products.Count()
        //            : _repository.Products.Where(e => e.Category.Name == category).Count()
        //    };
            
        //    return View(viewModel);
        //}

        public ActionResult List(string category, int page = 1)
        {
            ProductsListViewModel viewModel = new ProductsListViewModel();
            viewModel.CurrentCategory = category;
            viewModel.Products = _repository.Products
                .Where(p => category == null || p.Category.Name == category)
                .OrderBy(p => p.Id)
                .Skip((page - 1) * PageSize)
                .Take(PageSize);
            viewModel.PageNavigation = new PageNavigation
            {
                CurrentPage = page,
                ItemsPerPage = PageSize,
                TotalItems = category == null
                    ? _repository.Products.Count()
                    : _repository.Products.Where(e => e.Category.Name == category).Count()
            };

            return View(viewModel);
        }
        public ActionResult ProductInfo(int id)
        {
            var product = _repository.Products.Where(x => x.Id == id).FirstOrDefault();
            return View(product);
        }

        public string GetImage(int id)
        {
            Product prod = _repository.Products.FirstOrDefault(p => p.Id == id);
            if (prod != null)
            {
                return prod.ImagePath;
            }
            else
            {
                return null;
            }
        }
    }
}
