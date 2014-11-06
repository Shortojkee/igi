using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyShop.Domain.Entities;

namespace MyShop.Domain.Abstract
{
    public interface IPersonRepository
    {
        IQueryable<Person> Persons { get; }
        void SavePerson(Person person);
        Person DeletePerson(int id);
    }
}