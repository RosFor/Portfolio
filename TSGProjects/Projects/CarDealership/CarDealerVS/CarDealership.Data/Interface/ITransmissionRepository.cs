using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Interface
{
    public interface ITransmissionRepository
    {
        List<Transmission> GetAll();
        Transmission GetByID(int transmissionID);
    }
}
