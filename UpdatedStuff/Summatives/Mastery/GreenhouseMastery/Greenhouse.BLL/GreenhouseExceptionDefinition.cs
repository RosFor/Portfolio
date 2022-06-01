using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greenhouse.BLL
{
    public class GreenhouseExceptionDefinition : Exception
    {
        public GreenhouseExceptionDefinition() { }

        public GreenhouseExceptionDefinition(string message) : base(message) { }

        public GreenhouseExceptionDefinition(string message, Exception inner)
            : base(message, inner) { }
    }
}
