using symulator_rejestru.Exceptions;
using System;

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
            if (mSrc.value == null)
            {
                if (mSrc.level2 != null)
                {
                    mSrc.value = processor.GetRegister().GetRegister((Register.REGISTERS)mSrc.register, (Register.LEVEL)mSrc.level1, (Register.LEVEL)mSrc.level2);
                }
                else if (mSrc.level1 != null)
                {
                    mSrc.value = processor.GetRegister().GetRegister((Register.REGISTERS)mSrc.register, (Register.LEVEL)mSrc.level1);
                }
                else if (mSrc.register != null)
                {
                    mSrc.value = (int)processor.GetRegister().GetRegister((Register.REGISTERS)mSrc.register);
                }
            }
            if (mDest.level1 == null)
            {
                processor.GetRegister().SetRegister( (Register.REGISTERS) mDest.register, (uint)mSrc.value);
            }
            else if (mDest.level2 == null)
            {
                processor.GetRegister().SetRegister((Register.REGISTERS)mDest.register, (Register.LEVEL)mDest.level1, (ushort)mSrc.value);
            }
            else
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
                    SetRegister(dest.ToCharArray()[1], this.dest);
                }
                else if (dest.Length == 2)
                {
                    SetRegister(dest.ToCharArray()[0], this.dest);
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
                    SetRegister(src.ToCharArray()[0], this.src);
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
                    SetRegister(src.ToCharArray()[1], this.src);
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

            private MemoryItem SetRegister(char letter, MemoryItem mem)
            {
                switch (letter)
                {
                    case 'a':
                        mem.register = Register.REGISTERS.A;
                        break;
                    case 'b':
                        mem.register = Register.REGISTERS.B;
                        break;
                    case 'c':
                        mem.register = Register.REGISTERS.C;
                        break;
                    case 'd':
                        mem.register = Register.REGISTERS.D;
                        break;
                }
                return mem;
            }
        }
    }
}
