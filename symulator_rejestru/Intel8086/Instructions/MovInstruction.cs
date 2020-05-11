using symulator_rejestru.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace symulator_rejestru.Intel8086.Instructions
{
    public class MovInstruction : TwoParamsInstruction<Object>
    {
        private MemoryItem mDest;
        private MemoryItem mSrc;

        private MovInstruction(MemoryItem dest, MemoryItem src)
        {
            mDest = dest;
            mSrc = src;
        }

        public override void ExecuteCommand(Processor processor)
        {
            if (mDest.level1 == null) {
                processor.GetRegister().SetRegister((Register.REGISTERS)mDest.register, (uint)mSrc.value);
            } 
            else if(mDest.level2 == null)
            {
                processor.GetRegister().SetRegister((Register.REGISTERS)mDest.register, (Register.LEVEL)mDest.level1, (ushort)mSrc.value);
            } else
            {
                processor.GetRegister().SetRegister((Register.REGISTERS)mDest.register, (Register.LEVEL)mDest.level1, (Register.LEVEL)mDest.level2, (byte)mSrc.value);
            }
        }

        public class MovInstructionBuilder
        {
            MemoryItem dest;
            MemoryItem src;
            public MovInstructionBuilder()
            {
                dest = new MemoryItem();
                src = new MemoryItem();
            }

            public MovInstructionBuilder SetDestination(string dest)
            {
                if (dest.Length == 3)
                {
                    SetRegister(dest.ToCharArray()[1]);
                }
                else if (dest.Length == 2)
                {
                    SetRegister(dest.ToCharArray()[0]);
                    this.dest.level1 = Register.LEVEL.LOW;
                    if (dest.ToCharArray()[1] == 'l')
                    {
                        this.dest.level2 = Register.LEVEL.LOW;
                    }
                    else if (dest.ToCharArray()[1] == 'h')
                    {
                        this.dest.level2 = Register.LEVEL.HIGH;
                    }
                }
                else
                {
                    throw new UnknownInstructionException($"Błąd składni dest '{dest}'");
                }
                return this;
            }

            public MovInstructionBuilder SetSource(string src)
            {
                if (int.TryParse(src, out int res))
                {
                    this.src.value = res;
                }
                else if (src.Length == 2)
                {
                    SetRegister(src.ToCharArray()[0]);
                    this.src.level1 = Register.LEVEL.LOW;
                    if (src.ToCharArray()[1] == 'l')
                    {
                        this.src.level2 = Register.LEVEL.LOW;
                    }
                    else if (src.ToCharArray()[1] == 'h') 
                    {
                        this.src.level2 = Register.LEVEL.HIGH;
                    }
                }
                else if (src.Length == 3)
                {
                    SetRegister(src.ToCharArray()[1]);
                }
                else
                {
                    throw new UnknownInstructionException($"Błąd składni src '{src}'");
                }
                return this;
            }

            public MovInstruction Build()
            {
                if ((src.value == null && src.register == null) || dest.register == null) throw new UnknownInstructionException("Niepoprawnie skonfigurowany builder");
                return new MovInstruction(dest, src);
            }

            private void SetRegister(char letter)
            {
                switch (letter)
                {
                    case 'a':
                        dest.register = Register.REGISTERS.A;
                        break;
                    case 'b':
                        dest.register = Register.REGISTERS.B;
                        break;
                    case 'c':
                        dest.register = Register.REGISTERS.C;
                        break;
                    case 'd':
                        dest.register = Register.REGISTERS.D;
                        break;
                }
            }
        }
    }
}
