using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyShop.Domain.Entities;

namespace MyShop.Domain.Abstract
{
    public interface IProductApiRepository
    {
            IEnumerable<Product> GetAll();
            Product Get(int id);
            Product Add(Product item);
            void Remove(int id);
            bool Update(Product item);

    }
}
