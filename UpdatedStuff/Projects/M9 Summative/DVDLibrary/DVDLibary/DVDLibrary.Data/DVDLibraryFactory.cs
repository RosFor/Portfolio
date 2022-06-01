using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDLibrary.Data
{
    public static class DVDLibraryFactory
    {
        public static iDVDRepository GetRepository()
        {
            switch(Settings.GetRepository())
            {
                case "ADO":
                    return new DVDRepositoryADO();
                case "Mock":
                    return new DVDRepositoryMock();
                default:
                    throw new Exception("Could not find valid Repository configuration value.");

            }
        }
    }
}
