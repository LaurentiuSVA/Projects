using System;

namespace iQuest.VendingMachine.Exceptions
{
    public class InvalidPasswordException : Exception
    {
        public InvalidPasswordException() { }

        public InvalidPasswordException(string message) : base(message) { }
    }
}
