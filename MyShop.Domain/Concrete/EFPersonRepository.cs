using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyShop.Domain.Abstract;
using MyShop.Domain.Entities;

namespace MyShop.Domain.Concrete
{
    public class EFPersonRepository : IPersonRepository
    {
        MyShopContext context = new MyShopContext();
        public IQueryable<Person> Persons { get { return context.People; } }
        public void SavePerson(Person person)
        {
            throw new NotImplementedException();
        }

        public Person DeletePerson(int id)
        {
            throw new NotImplementedException();
        }
    }
}