using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace symulator_rejestru.Intel8086.Instructions
{
    public class MemoryItem
    {
        public Register.REGISTERS? register;
        public Register.LEVEL? level1;
        public Register.LEVEL? level2;
        public int? value;
    }
}
