using CarDealership.Data.Interface;
using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Mock
{
    public class ConditionRepositoryMock : IConditionRepository
    {
        public List<Condition> _conditionMock = new List<Condition>()
            {
            new Condition
                { ConditionID = 1, ConditionType = "MockNew" },
            new Condition
                { ConditionID = 2, ConditionType = "MockUsed"}
            };
        public List<Condition> GetAll()
        {
            throw new NotImplementedException();
        }

        public Condition GetByID(int conditionID)
        {
            throw new NotImplementedException();
        }
    }
}
