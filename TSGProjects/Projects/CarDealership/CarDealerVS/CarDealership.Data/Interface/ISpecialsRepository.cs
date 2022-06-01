using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Interface
{
    public interface ISpecialsRepository
    {
        List<Specials> GetAll();
        Specials GetByID(int specialsID);
        void Delete(int specialsID);
        void Insert(Specials specials);
    }
}
