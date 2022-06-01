using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Interface
{
    public interface IColorRepository
    {
        List<Color> GetAll();
        Color GetByID(int colorID);
    }
}
