using CarDealership.Data.Interface;
using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Mock
{
    public class PurchaseTypesRepositoryMock : IPurchaseTypesRepository
    {
        public List<PurchaseTypes> _purchaseTypeMock = new List<PurchaseTypes>()
            {
            new PurchaseTypes
                { PurchaseTypeID = 1, PurchaseType = "MockCash" },
            new PurchaseTypes
                { PurchaseTypeID = 2, PurchaseType = "MockDealerFinance"},
            new PurchaseTypes
                { PurchaseTypeID = 3, PurchaseType = "MockBankFinance"}
            };
        public List<PurchaseTypes> GetAll()
        {
            throw new NotImplementedException();
        }

        public PurchaseTypes GetByID(int purchaseTypeID)
        {
            throw new NotImplementedException();
        }
    }
}
