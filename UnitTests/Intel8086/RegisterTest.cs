using Microsoft.VisualStudio.TestTools.UnitTesting;
using symulator_rejestru.Intel8086;
using System;

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
        public void TestRegisterString()
        {
            mRegister.SetRegister("eax", 0xFEDCBA09);
            mRegister.SetRegister("ebx", 0xEDCBA098);
            mRegister.SetRegister("ecx", 0xDCBA0987);
            mRegister.SetRegister("edx", 0xCBA09876);

            Assert.AreEqual(unchecked((UInt32)0xFEDCBA09), mRegister.GetRegister("eax"));
            Assert.AreEqual(unchecked((UInt32)0xBA09), mRegister.GetRegister("ax"));
            Assert.AreEqual(unchecked((UInt32)0xBA), mRegister.GetRegister("ah"));
            Assert.AreEqual(unchecked((UInt32)0x09), mRegister.GetRegister("al"));

            Assert.AreEqual(unchecked((UInt32)0xEDCBA098), mRegister.GetRegister("ebx"));
            Assert.AreEqual(unchecked((UInt32)0xA098), mRegister.GetRegister("bx"));
            Assert.AreEqual(unchecked((UInt32)0xA0), mRegister.GetRegister("bh"));
            Assert.AreEqual(unchecked((UInt32)0x98), mRegister.GetRegister("bl"));

            Assert.AreEqual(unchecked((UInt32)0xDCBA0987), mRegister.GetRegister("ecx"));
            Assert.AreEqual(unchecked((UInt32)0x0987), mRegister.GetRegister("cx"));
            Assert.AreEqual(unchecked((UInt32)0x09), mRegister.GetRegister("ch"));
            Assert.AreEqual(unchecked((UInt32)0x87), mRegister.GetRegister("cl"));

            Assert.AreEqual(unchecked((UInt32)0xCBA09876), mRegister.GetRegister("edx"));
            Assert.AreEqual(unchecked((UInt32)0x9876), mRegister.GetRegister("dx"));
            Assert.AreEqual(unchecked((UInt32)0x98), mRegister.GetRegister("dh"));
            Assert.AreEqual(unchecked((UInt32)0x76), mRegister.GetRegister("dl"));
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
