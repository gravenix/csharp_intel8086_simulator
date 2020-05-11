using symulator_rejestru.Intel8086.Instructions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            string[] parts = cmd.Split(' ');
            if (parts[1].Contains(','))
            {
                parts = new string[] { parts[0].Trim().ToLower(), parts[1].Trim().ToLower().Replace(",", ""), parts[2].Trim().ToLower() };
            }
            if (parts[0] == "mov")
            {
                return new MovInstruction.MovInstructionBuilder().SetDestination(parts[1]).SetSource(parts[2]).Build();
            }
            //if (parts[0] != "MOV")
            //{
            //    MessageBox.Show("The only supported command is 'MOV'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return null;
            //}
            //string source = "", destination = "";
            //if (parts[1].Contains(','))
            //{
            //    string[] subparts = parts[1].Split(',');
            //    if (subparts.Length == 1) destination = subparts[0];
            //    else
            //    {
            //        destination = subparts[0];
            //        if (subparts[1].Length > 0) source = subparts[1];
            //        else source = parts[2];
            //    }
            //}
            //if (destination == "")
            //{
            //    destination = parts[1];
            //}
            //short val = 0;
            //if (short.TryParse(source, out short n))
            //{
            //    val = Convert.ToInt16(source);
            //}
            //else
            //{
            //    val = getRegister(source);
            //}
            //setRegister(destination, val);
            return null;
        }
    }
}
