using symulator_rejestru.Intel8086.Instructions;
using System.Linq;

namespace symulator_rejestru.Intel8086
{
    public class Processor
    {
        private Register mRegister;

        public Processor()
        {
            mRegister = new Register();
        }

        public Register GetRegister()
        {
            return mRegister;
        }

        public void ExecuteCommand(AssemblerInstruction instruction)
        {
            instruction.ExecuteCommand(this);
        }

        public static AssemblerInstruction ParseInstruction(string cmd)
        {
            string[] parts = cmd.Trim().Split(' ');
            if (parts[1].Contains(','))
            {
                parts = new string[] {
                    parts[0].Trim().ToLower(),
                    parts[1].Trim().ToLower().Replace(",", ""),
                    parts[2].Trim().ToLower()
                };
            }
            if (parts[0] == "mov")
            {
                return new MovInstruction.MovInstructionBuilder()
                    .SetDestination(parts[1])
                    .SetSource(parts[2])
                    .Build();
            }
            return null;
        }
    }
}
