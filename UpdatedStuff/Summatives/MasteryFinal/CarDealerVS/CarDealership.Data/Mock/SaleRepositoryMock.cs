using CarDealership.Data.Interface;
using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Mock
{
    public class SaleRepositoryMock : ISaleRepository
    {
        public List<Sale> GetAll()
        {
            throw new NotImplementedException();
        }

        public Sale GetByID(int saleID)
        {
            throw new NotImplementedException();
        }

        public void Insert(Sale sale)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Sale> ReportSale()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Sale> ReportSearch(ReportSearchParameters parameters)
        {
            throw new NotImplementedException();
        }
    }
}
