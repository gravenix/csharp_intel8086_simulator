using System;

namespace symulator_rejestru.Exceptions
{
    public class UnknownInstructionException : Exception
    {
        public UnknownInstructionException(string message) : base(message)
        {
        }
    }
}
