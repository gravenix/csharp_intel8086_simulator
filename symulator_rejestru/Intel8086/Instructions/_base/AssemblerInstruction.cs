using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace symulator_rejestru.Intel8086.Instructions
{
    public interface AssemblerInstruction
    {
        void ExecuteCommand(Processor p);
    }
}
