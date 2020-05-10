﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace symulator_rejestru.Intel8086
{
    public class Register
    {
        public enum REGISTERS { A, B, C, D };
        public enum LEVEL { HIGH, LOW };
        private UInt32 eax;
        private UInt32 ebx;
        private UInt32 ecx;
        private UInt32 edx;

        public Register()
        {
            eax = ebx = ecx = edx = 0;
        }

        public void SetRegister(REGISTERS type, UInt32 value)
        {
            switch (type)
            {
                case REGISTERS.A:
                    eax = value;
                    break;
                case REGISTERS.B:
                    ebx = value;
                    break;
                case REGISTERS.C:
                    ecx = value;
                    break;
                case REGISTERS.D:
                    edx = value;
                    break;
            }
        }

        public void SetRegister(REGISTERS type, LEVEL level, UInt16 value)
        {
            UInt32 reg = GetRegister(type);
            switch (level)
            {
                case LEVEL.HIGH:
                    reg = (UInt32)(value << 16) + (reg << 16 >> 16);
                    break;
                case LEVEL.LOW:
                    reg = reg >> 16 << 16;
                    reg += value;
                    break;
            }
            SetRegister(type, reg);
        }

        public void SetRegister(REGISTERS type, LEVEL level1, LEVEL level2, Byte value)
        {
            UInt16 reg = GetRegister(type, level1);
            switch (level2)
            {
                case LEVEL.HIGH:
                    reg = (UInt16)((value << 8) + ((UInt16)(reg << 8) >> 8));
                    break;
                case LEVEL.LOW:
                    reg = (UInt16)(reg >> 8 << 8);
                    reg += value;
                    break;
            }
            SetRegister(type, level1, reg);
        }

        public UInt32 GetRegister(REGISTERS type)
        {
            switch (type)
            {
                case REGISTERS.A:
                    return eax;
                case REGISTERS.B:
                    return ebx;
                case REGISTERS.C:
                    return ecx;
                case REGISTERS.D:
                    return edx;
            }
            return 0;
        }

        public UInt16 GetRegister(REGISTERS type, LEVEL level)
        {
            UInt32 reg = GetRegister(type);
            switch (level)
            {
                case LEVEL.HIGH:
                    reg = reg >> 16;
                    break;
                case LEVEL.LOW:
                    reg = reg << 16 >> 16;
                    break;
            }
            return (UInt16)reg;
        }

        public Byte GetRegister(REGISTERS type, LEVEL level1, LEVEL level2)
        {
            UInt16 reg = GetRegister(type, level1);
            switch (level2)
            {
                case LEVEL.HIGH:
                    reg = (UInt16)(reg >> 8);
                    break;
                case LEVEL.LOW:
                    reg = (UInt16)((UInt16) reg << 8>> 8);
                    break;
            }
            return (Byte)reg;
        }
    }
}
