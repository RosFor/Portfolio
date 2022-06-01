using Greenhouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greenhouse.Data
{
    public interface ITax
    {
        List<Taxes> ReadAll();
        Taxes ReadByID(string stateAbbr);
    }
}
