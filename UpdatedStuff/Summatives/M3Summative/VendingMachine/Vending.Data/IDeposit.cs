using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vending.Model;
using Vending.Model.Responses;

namespace Vending.Data
{
    public interface IDeposit
    {
        DepositResponse Deposit(Product product, decimal amountInserted);
    }
}
