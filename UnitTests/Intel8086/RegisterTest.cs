using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using symulator_rejestru.Intel8086;

namespace UnitTests
{
    [TestClass]
    public class RegisterTest
    {
        private Register mRegister;
        public RegisterTest()
        {
            mRegister = new Register();
        }

        [TestMethod]
        public void TestObject()
        {
            Assert.IsNotNull(mRegister);
        }

        [TestMethod]
        public void TestRegisters()
        {
            UInt32 value = 0xDEADBEEF;

            foreach (Register.REGISTERS reg in Enum.GetValues(typeof(Register.REGISTERS)))
            {
                // test read
                mRegister.SetRegister(reg, value);
                Assert.AreEqual(value, mRegister.GetRegister(reg));
                Assert.AreEqual(0xBEEF, mRegister.GetRegister(reg, Register.LEVEL.LOW));
                Assert.AreEqual(0xEF, mRegister.GetRegister(reg, Register.LEVEL.LOW, Register.LEVEL.LOW));
                Assert.AreEqual(0xBE, mRegister.GetRegister(reg, Register.LEVEL.LOW, Register.LEVEL.HIGH));
                Assert.AreEqual(0xDEAD, mRegister.GetRegister(reg, Register.LEVEL.HIGH));
                Assert.AreEqual(0xAD, mRegister.GetRegister(reg, Register.LEVEL.HIGH, Register.LEVEL.LOW));
                Assert.AreEqual(0xDE, mRegister.GetRegister(reg, Register.LEVEL.HIGH, Register.LEVEL.HIGH));

                // test write
                mRegister.SetRegister(reg, Register.LEVEL.LOW, 0xDEAD);
                mRegister.SetRegister(reg, Register.LEVEL.HIGH, 0xBEEF);
                Assert.AreEqual(0xBEEFDEAD, mRegister.GetRegister(reg));
                mRegister.SetRegister(reg, Register.LEVEL.HIGH, Register.LEVEL.LOW, 0xBE);
                mRegister.SetRegister(reg, Register.LEVEL.LOW, Register.LEVEL.LOW, 0xDE);
                Assert.AreEqual(0xBEBEDEDE, mRegister.GetRegister(reg));
                mRegister.SetRegister(reg, Register.LEVEL.HIGH, Register.LEVEL.HIGH, 0xFE);
                mRegister.SetRegister(reg, Register.LEVEL.LOW, Register.LEVEL.HIGH, 0xED);
                Assert.AreEqual(0xFEBEEDDE, mRegister.GetRegister(reg));
            }
        }
    }
}
