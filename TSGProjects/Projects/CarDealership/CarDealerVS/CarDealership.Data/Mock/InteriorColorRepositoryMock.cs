using CarDealership.Data.Interface;
using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Mock
{
    public class InteriorColorRepositoryMock : IInteriorColorRepository
    {
        public List<InteriorColor> _interiorColorMock = new List<InteriorColor>()
            {
            new InteriorColor
                { InteriorColorID = 1, InteriorColorName = "MockWhite" },
            new InteriorColor
                { InteriorColorID = 2, InteriorColorName = "MockCream"},
            new InteriorColor
                { InteriorColorID = 3, InteriorColorName = "MockBeige/Tan"},
            new InteriorColor
                { InteriorColorID = 4, InteriorColorName = "MockBrown"},
            new InteriorColor
                { InteriorColorID = 5, InteriorColorName = "MockGrey"},
            new InteriorColor
                { InteriorColorID = 6, InteriorColorName = "MockBlack"}
            };
        public List<InteriorColor> GetAll()
        {
            throw new NotImplementedException();
        }

        public InteriorColor GetByID(int interiorColorID)
        {
            throw new NotImplementedException();
        }
    }
}
