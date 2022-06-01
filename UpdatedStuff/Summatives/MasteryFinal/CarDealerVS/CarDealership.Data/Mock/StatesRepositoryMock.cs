using CarDealership.Data.Interface;
using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Mock
{
    public class StatesRepositoryMock : IStatesRepository
    {
        public List<States> _statesMock = new List<States>()
            {
            new States
                { StateID = 1, StateName = "MockMinnesota", StateAbbreviation = "MMN" },
            new States
                { StateID = 2, StateName = "MockNewJersey", StateAbbreviation = "MNJ" },
            new States
                { StateID = 3, StateName = "MockOregon", StateAbbreviation = "MOR" },
            new States
                { StateID = 4, StateName = "MockTexas", StateAbbreviation = "MTX" },
            new States
                { StateID = 5, StateName = "MockColorado", StateAbbreviation = "MCO" }
            };
        public List<States> GetAll()
        {
            throw new NotImplementedException();
        }

        public States GetByID(int stateID)
        {
            throw new NotImplementedException();
        }
    }
}
