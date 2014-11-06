using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MyShop.Domain.Abstract;
using MyShop.Domain.Concrete;
using MyShop.Domain.Entities;

namespace MyShop.WebUI.Controllers
{
    public class ProductsApiController : ApiController
    {
        private IProductApiRepository _repository = ProductApiRepository.getRepository();

        public IEnumerable<Product> GetAllProducts()
        {
            return _repository.GetAll();
        }

        public Product GetProduct(int id)
        {
            return _repository.Get(id);
        }

        public Product PostProduct(Product item)
        {
            return _repository.Add(item);
        }

        public bool PutProduct(Product item)
        {
            return _repository.Update(item);
        }

        public void DeleteProduct(int id)
        {
            _repository.Remove(id);
        }

    }
}
