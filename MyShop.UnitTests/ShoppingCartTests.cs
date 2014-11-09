using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyShop.Domain.Abstract;
using MyShop.Domain.Entities;
using MyShop.WebUI.Controllers;
using MyShop.WebUI.Models;

namespace MyShop.UnitTests
{
    [TestClass]
    public class ShoppingCartTests
    {
        [TestMethod]
        public void Can_Add_New_Lines()
        {
            // Arrange - создание условий для теста
            Product p1 = new Product {Id = 1, Name = "LG"};
            Product p2 = new Product {Id = 2, Name = "Sony"};
            Product p3 = new Product {Id = 3, Name = "Lenovo"};

            ShoppingCart cart = new ShoppingCart();

            // Act - выполнение теста
            cart.AddItem(p1, 1);
            cart.AddItem(p2, 2);
            cart.AddItem(p3, 3);

            OrderLine[] results = cart.Lines.ToArray();

            // Assert - проверка резултатов
            Assert.AreEqual(results.Length, 3);
            Assert.AreEqual(results[0].Product, p1);
            Assert.AreEqual(results[1].Product, p2);
            Assert.AreEqual(results[2].Product, p3);
        }

        [TestMethod]
        public void Can_Add_Quantity()
        {
            // Arrange - создание условий для теста
            Product p1 = new Product { Id = 1, Name = "LG" };
            Product p2 = new Product { Id = 2, Name = "Sony" };
            Product p3 = new Product { Id = 3, Name = "Lenovo" };

            ShoppingCart cart = new ShoppingCart();

            // Act - выполнение теста
            cart.AddItem(p1, 1);
            cart.AddItem(p2, 2);
            cart.AddItem(p3, 3);
            cart.AddItem(p1, 3);
            cart.AddItem(p2, 1);
            OrderLine[] results = cart.Lines.ToArray();

            // Assert - проверка резултатов
            Assert.AreEqual(results.Length, 3);
            Assert.AreEqual(results[0].Quantity, 4);
            Assert.AreEqual(results[1].Quantity, 3);
            Assert.AreEqual(results[2].Quantity, 3);
        }

        [TestMethod]
        public void Can_Remove_Lines()
        {
            // Arrange - создание условий для теста
            Product p1 = new Product { Id = 1, Name = "LG" };
            Product p2 = new Product { Id = 2, Name = "Sony" };
            Product p3 = new Product { Id = 3, Name = "Lenovo" };
            ShoppingCart cart = new ShoppingCart();
            cart.AddItem(p1, 1);
            cart.AddItem(p2, 2);
            cart.AddItem(p3, 3);
            cart.AddItem(p1, 3);
            cart.AddItem(p2, 1);

            // Act - выполнение теста
            cart.RemoveLine(p1);

            // Assert - проверка резултатов
            Assert.AreEqual(cart.Lines.Count(), 2);
            Assert.AreEqual(cart.Lines.Where(p => p.Product == p1).Count(), 0);
        }

        [TestMethod]
        public void Calculate_Total_Price()
        {
            // Arrange - создание условий для теста
            Product p1 = new Product { Id = 1, Name = "LG", Price = 300};
            Product p2 = new Product { Id = 2, Name = "Sony", Price = 600 };
            Product p3 = new Product { Id = 3, Name = "Lenovo", Price = 200 };
            ShoppingCart cart = new ShoppingCart();
            cart.AddItem(p1, 1);
            cart.AddItem(p2, 2);
            cart.AddItem(p3, 3);

            // Act - выполнение теста
            decimal totalPrice = cart.ComputeTotalValue();

            // Assert - проверка резултатов
            Assert.AreEqual(totalPrice, 2100);
        }
    }
}
