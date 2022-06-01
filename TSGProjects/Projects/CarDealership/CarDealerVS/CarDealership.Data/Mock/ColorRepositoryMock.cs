using CarDealership.Data.Interface;
using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Mock
{
    public class ColorRepositoryMock : IColorRepository
    {
        public List<Color> _colorMock = new List<Color>()
            {
            new Color
                { ColorID = 1, ColorName = "MockWhite" },
            new Color
                { ColorID = 2, ColorName = "MockSilver"},
            new Color
                { ColorID = 3, ColorName = "MockBlack"},
            new Color
                { ColorID = 4, ColorName = "MockRed"},
            new Color
                { ColorID = 5, ColorName = "MockYellow"},
            new Color
                { ColorID = 6, ColorName = "MockGreen"},
            new Color
                { ColorID = 7, ColorName = "MockBlue"}
            };
        public List<Color> GetAll()
        {
            throw new NotImplementedException();
        }

        public Color GetByID(int colorID)
        {
            throw new NotImplementedException();
        }
    }
}
