using System;
using System.Linq;
using System.Runtime;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyShop.Domain.Abstract;
using MyShop.Domain.Entities;
using MyShop.WebUI.Controllers;
using MyShop.WebUI.Models;

namespace MyShop.UnitTests
{
    [TestClass]
    public class CartControllerTests
    {
        [TestMethod]
        public void Can_Add_To_Cart()
        {
            //Arrange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[]
            {
                new Product {Id = 1, Name = "LG"},
                new Product {Id = 2, Name = "Sony"},
                new Product {Id = 3, Name = "Lenovo"}
            }.AsQueryable());
            ShoppingCart cart = new ShoppingCart();
            CartController controller = new CartController(mock.Object);
            //Act
            controller.AddToCart(cart, 1, null);
            controller.AddToCart(cart, 2, null);

            //Assert
            Assert.AreEqual(cart.Lines.Count(), 2);
            Assert.AreEqual(cart.Lines.ToArray()[0].Product.Id, 1);
            Assert.AreEqual(cart.Lines.ToArray()[1].Product.Id, 2);
        }

        [TestMethod]
        public void Can_Redirect_To_Cart()
        {
            //Arrange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[]
            {
                new Product {Id = 1, Name = "LG"},
                new Product {Id = 2, Name = "Sony"},
                new Product {Id = 3, Name = "Lenovo"}
            }.AsQueryable());
            ShoppingCart cart = new ShoppingCart();
            CartController controller = new CartController(mock.Object);
            //Act
            RedirectToRouteResult result = controller.AddToCart(cart, 1, "redirectUrl");

            //Assert
            Assert.AreEqual(result.RouteValues["action"], "Index");
            Assert.AreEqual(result.RouteValues["returnUrl"], "redirectUrl");
        }

        [TestMethod]
        public void Can_View_Cart_Contents()
        {
            // Arrange
            ShoppingCart cart = new ShoppingCart();
            CartController controller = new CartController(null);

            // Act
            CartIndexViewModel result = (CartIndexViewModel)controller.Index(cart, "Url").ViewData.Model;

            // Assert
            Assert.AreSame(result.Cart, cart);
            Assert.AreEqual(result.ReturnUrl, "Url");
        }

    }
}
