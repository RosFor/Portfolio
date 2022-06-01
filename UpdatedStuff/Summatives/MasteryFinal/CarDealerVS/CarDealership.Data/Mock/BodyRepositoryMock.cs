using CarDealership.Data.Interface;
using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Mock
{
    public class BodyRepositoryMock : IBodyRepository
    {
        public List<Body> _bodyMock = new List<Body>()
            {
            new Body
                { BodyID = 1, BodyStyle = "MockCar" },
            new Body
                { BodyID = 2, BodyStyle = "MockSUV"},
            new Body
                { BodyID = 3, BodyStyle = "MockTruck"},
            new Body
                { BodyID = 4, BodyStyle = "MockVan"}
            };

        public List<Body> GetAll()
        {
            throw new NotImplementedException();
        }

        public Body GetByID(int bodyID)
        {
            throw new NotImplementedException();
        }

    }
}
