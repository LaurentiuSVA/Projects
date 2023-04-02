using System;

namespace iQuest.VendingMachine.Exceptions
{
    public class InvalidCardNumberException : Exception
    {
        public InvalidCardNumberException() { }

        public InvalidCardNumberException(string message) : base(message) { }
    }
}
