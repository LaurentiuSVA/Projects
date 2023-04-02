using System;

namespace iQuest.VendingMachine.Exceptions
{
    public class InvalidColumnException : Exception
    {
        public InvalidColumnException() { }

        public InvalidColumnException(string message) : base(message) { }
    }
}
