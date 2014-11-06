using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyShop.Domain.Entities;

namespace MyShop.WebUI.Binders
{
    public class CartModelBinder : IModelBinder
    {
        private const string sessionKey = "Cart";

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            // get the Cart from the session
            ShoppingCart cart = (ShoppingCart) controllerContext.HttpContext.Session[sessionKey];

            // create the Cart if there wasn't one in the session data
            if (cart == null)
            {
                cart = new ShoppingCart();
                controllerContext.HttpContext.Session[sessionKey] = cart;
            }

            // return the cart
            return cart;

        }
    }
}