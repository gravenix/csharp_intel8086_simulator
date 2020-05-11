using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace symulator_rejestru.Exceptions
{
    public class UnknownInstructionException : Exception
    {
        public UnknownInstructionException(string message) : base(message)
        {
        }
    }
}
