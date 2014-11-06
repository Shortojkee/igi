using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyShop.Domain.Abstract;
using MyShop.Domain.Entities;

namespace MyShop.Domain.Concrete
{
    public class EFProductRepository : IProductRepository
    {
        MyShopContext context = new MyShopContext();
        public IQueryable<Product> Products { get { return context.Products; } }

        public void SaveProduct(Product product)
        {
            if (product.Id == 0)
            {
                 context.Products.Add(product);
            }
            else
            {
                Product dbEntry = context.Products.Find(product.Id);
                if (dbEntry != null)
                {
                    dbEntry.Name = product.Name;
                    dbEntry.Description = product.Description;
                    dbEntry.Price = product.Price;
                    dbEntry.CategoryId = product.CategoryId;
                    dbEntry.ImagePath = product.ImagePath;
                    dbEntry.ImageMimeType = product.ImageMimeType;
                }
            }
            context.SaveChanges();
        }

        public Product DeleteProduct(int id)
        {
            Product dbEntry = context.Products.Find(id);
            if (dbEntry != null)
            {
                context.Products.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

    }


}