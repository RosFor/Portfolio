using CarDealership.Data.Interface;
using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Mock
{
    public class SpecialsRepositoryMock : ISpecialsRepository
    {
        public void Delete(int specialsID)
        {
            throw new NotImplementedException();
        }

        public List<Specials> GetAll()
        {
            throw new NotImplementedException();
        }

        public Specials GetByID(int specialsID)
        {
            throw new NotImplementedException();
        }

        public void Insert(Specials specials)
        {
            throw new NotImplementedException();
        }
    }
}
