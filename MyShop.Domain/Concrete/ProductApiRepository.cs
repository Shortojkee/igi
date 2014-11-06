using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyShop.Domain.Abstract;
using MyShop.Domain.Entities;

namespace MyShop.Domain.Concrete
{
    public class ProductApiRepository : IProductApiRepository
    {
        MyShopContext context = new MyShopContext();
        private static ProductApiRepository _repository = new ProductApiRepository();

        public static IProductApiRepository getRepository()
        {
            return _repository;
        }

        public IEnumerable<Product> GetAll()
        {
            return context.Products;
        }

        public Product Get(int id)
        {
            var matches = context.Products.Where(r => r.Id == id);
            return matches.Count() > 0 ? matches.First() : null;
        }

        public Product Add(Product item)
        {
            context.Products.Add(item);
            context.SaveChanges();
            return item;
        }

        public void Remove(int id)
        {
            Product item = Get(id);
            if (item != null)
            {
                context.Products.Remove(item);
                context.SaveChanges();
            }
        }

        public bool Update(Product item)
        {
            Product storedItem = Get(item.Id);
            if (storedItem != null)
            {
                storedItem.Name = item.Name;
                storedItem.Description = item.Description;
                storedItem.Price = item.Price;
                storedItem.CategoryId = item.CategoryId;
                storedItem.ImagePath = item.ImagePath;
                storedItem.ImageMimeType = item.ImageMimeType;
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
