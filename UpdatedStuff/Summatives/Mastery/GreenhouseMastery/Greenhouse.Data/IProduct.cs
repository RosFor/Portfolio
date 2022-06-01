using Greenhouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greenhouse.Data
{
    public interface IProduct
    {
        List<Product> ReadAll();
        Product ReadByID(string productName);
    }
}
