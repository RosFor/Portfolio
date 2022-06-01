using CarDealership.Data.Interface;
using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Mock
{
    public class TransmissionRepositoryMock : ITransmissionRepository
    {
        public List<Transmission> _transmissionMock = new List<Transmission>()
            {
            new Transmission
                { TransmissionID = 1, TransmissionType = "MockManual" },
            new Transmission
                { TransmissionID = 2, TransmissionType = "MockAutomatic"}
            };
        public List<Transmission> GetAll()
        {
            throw new NotImplementedException();
        }

        public Transmission GetByID(int transmissionID)
        {
            throw new NotImplementedException();
        }
    }
}
