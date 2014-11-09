using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyShop.Domain.Abstract;
using MyShop.Domain.Entities;
using MyShop.WebUI.Controllers;
using MyShop.WebUI.Models;
using System.Web;

namespace MyShop.UnitTests
{
    [TestClass]
    public class AdminTests
    {
        [TestMethod]
        public void Can_Edit_Product()
        {
            // Arrange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[] {
                new Product {Id = 1, Name = "LG"},
                new Product {Id = 2, Name = "Sony"},
                new Product {Id = 3, Name = "Lenovo"},
              }.AsQueryable());
            var target = new AdminController(mock.Object, null);

            // Act
            var p1 = target.Edit(1).ViewData.Model as Product;
            var p2 = target.Edit(2).ViewData.Model as Product;
            var p3 = target.Edit(3).ViewData.Model as Product;

            // Assert
            Assert.AreEqual(1, p1.Id);
            Assert.AreEqual(2, p2.Id);
            Assert.AreEqual(3, p3.Id);
        }

        [TestMethod]
        public void Cannot_Edit_Nonexistent_Product()
        {
            // Arrange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
                        mock.Setup(m => m.Products).Returns(new Product[] {
                new Product {Id = 1, Name = "LG"},
                new Product {Id = 2, Name = "Sony"},
                new Product {Id = 3, Name = "Lenovo"},
              }.AsQueryable());
            var target = new AdminController(mock.Object, null);

            // Act
            var result = (Product)target.Edit(4).ViewData.Model;

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void Can_Save_Valid_Changes()
        {
            // Arrange 
            var mock = new Mock<IProductRepository>();
            var target = new AdminController(mock.Object, null);
            var product = new Product { Name = "Lenovo" };

            // Act - try to save the product
            ActionResult result = target.Edit(product, null);

            // Assert
            mock.Verify(m => m.SaveProduct(product));
            Assert.IsNotInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void Cannot_Save_Invalid_Changes()
        {
            // Arrange
            var mock = new Mock<IProductRepository>();
            var target = new AdminController(mock.Object, null);
            var product = new Product { Name = "Lenovo" };
            target.ModelState.AddModelError("error", "error");

            // Act
            ActionResult result = target.Edit(product, null);

            // Assert
            mock.Verify(m => m.SaveProduct(It.IsAny<Product>()), Times.Never());
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void Can_Delete_Valid_Products()
        {
            // Arrange
            var mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[] {
                new Product {Id = 1, Name = "LG"},
                new Product {Id = 2, Name = "Sony"},
                new Product {Id = 3, Name = "Lenovo"},
              }.AsQueryable());
            var target = new AdminController(mock.Object, null);
            const int id = 2;

            // Act 
            target.Delete(id);

            // Assert
            mock.Verify(m => m.DeleteProduct(id));
        }

    }
}
