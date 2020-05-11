using symulator_rejestru.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace symulator_rejestru.Intel8086.Instructions
{
    public abstract class TwoParamsInstruction<T> : AssemblerInstruction
    {
        protected T param1 { get; set; }
        protected T param2 { get; set; }

        public abstract void ExecuteCommand(Processor processor);
    }
}
