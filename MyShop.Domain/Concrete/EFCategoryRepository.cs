using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyShop.Domain.Abstract;
using MyShop.Domain.Entities;

namespace MyShop.Domain.Concrete
{
    public class EFCategoryRepository : ICategoryRepository
    {
        MyShopContext context = new MyShopContext();
        public IQueryable<Category> Categories { get { return context.Categories; } }
    }
}
