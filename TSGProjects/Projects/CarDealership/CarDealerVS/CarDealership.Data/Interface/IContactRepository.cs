using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Interface
{
    public interface IContactRepository
    {
        List<Contact> GetAll();
        void Insert(Contact contact);
    }
}
