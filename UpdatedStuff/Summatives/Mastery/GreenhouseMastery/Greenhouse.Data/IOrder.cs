using Greenhouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greenhouse.Data
{
    public interface IOrder
    {
        Order CreateOrder(Order order);
        List<Order> ReadAll(DateTime orderDate);
        Order ReadByID(DateTime orderDate, int orderNumber);
        Order UpdateOrder(Order orderToUpdate);
        bool DeleteOrder(DateTime orderDate, int orderNumber);

    }
}
