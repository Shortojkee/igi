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
    public class CartController : Controller
    {
        private IProductRepository _repository;

        public CartController(IProductRepository repository)
        {
            _repository = repository;
        }

        public ViewResult Index(ShoppingCart cart, string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }

        public PartialViewResult Summary(ShoppingCart cart)
        {
            return PartialView(cart);
        }

        [HttpPost]
        public ActionResult Checkout(ShoppingCart cart, ShippingDetails shippingDetails)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }
            if (ModelState.IsValid)
            {
                //orderProcessor.ProcessOrder(cart, shippingDetails);
                cart.Clear();
                if (Request.IsAjaxRequest())
                {
                    return PartialView("Completed");
                }
                return View("Completed");
            }
            else
            {
                return View(shippingDetails);
            }
        }
        public ViewResult Checkout()
        {

            return View(new ShippingDetails());
        }

        public RedirectToRouteResult AddToCart(ShoppingCart cart, int id, string returnUrl)
        {
            Product product = _repository.Products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                cart.AddItem(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(ShoppingCart cart, int id, string returnUrl)
        {
            Product product = _repository.Products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                cart.RemoveLine(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

    }
}