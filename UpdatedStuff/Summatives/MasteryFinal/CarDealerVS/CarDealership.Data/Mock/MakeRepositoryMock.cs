using CarDealership.Data.Interface;
using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Mock
{
    public class MakeRepositoryMock : IMakeRepository
    {
        public List<Make> GetAll()
        {
            throw new NotImplementedException();
        }

        public Make GetByID(int makeID)
        {
            throw new NotImplementedException();
        }

        public void Insert(Make make)
        {
            throw new NotImplementedException();
        }
    }
}
