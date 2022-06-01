using CarDealership.Data.Interface;
using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Mock
{
    public class ContactRepositoryMock : IContactRepository
    {
        public List<Contact> GetAll()
        {
            throw new NotImplementedException();
        }

        public Contact GetByID(int contactID)
        {
            throw new NotImplementedException();
        }

        public void Insert(Contact contact)
        {
            throw new NotImplementedException();
        }
    }
}
