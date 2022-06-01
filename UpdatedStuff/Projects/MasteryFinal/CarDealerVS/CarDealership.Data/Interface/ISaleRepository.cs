using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Interface
{
    public interface ISaleRepository
    {
        List<Sale> GetAll();
        Sale GetByID(int saleID);
        void Insert(Sale sale);
        IEnumerable<Sale> ReportSale();
        IEnumerable<Sale> ReportSearch(ReportSearchParameters parameters);
    }
}
