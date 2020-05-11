using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using symulator_rejestru.Intel8086;
using symulator_rejestru.Intel8086.Instructions;

namespace UnitTests.Intel8086
{
    [TestClass]
    public class ProcessorTest
    {
        [TestMethod]
        public void TestHappyCommand()
        {
            Processor p = new Processor();

            AssemblerInstruction cmd = Processor.ParseInstruction("MOV EAX, 10");
            p.ExecuteCommand(cmd);
            Assert.AreEqual((UInt32)10, p.GetRegister().GetRegister(Register.REGISTERS.A));

            cmd = Processor.ParseInstruction("MOV CX, 56");
            p.ExecuteCommand(cmd);
            Assert.AreEqual((UInt32)56, p.GetRegister().GetRegister(Register.REGISTERS.C, Register.LEVEL.LOW));

            cmd = Processor.ParseInstruction("MOV BL, 250");
            p.ExecuteCommand(cmd);
            Assert.AreEqual((UInt32)250, p.GetRegister().GetRegister(Register.REGISTERS.B, Register.LEVEL.LOW, Register.LEVEL.LOW));

            cmd = Processor.ParseInstruction("MOV DH, 11");
            p.ExecuteCommand(cmd);
            Assert.AreEqual((UInt32)11, p.GetRegister().GetRegister(Register.REGISTERS.D, Register.LEVEL.LOW, Register.LEVEL.HIGH));
        }
    }
}
