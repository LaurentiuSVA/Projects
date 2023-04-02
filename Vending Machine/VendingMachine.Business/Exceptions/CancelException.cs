using System;

namespace iQuest.VendingMachine.Exceptions
{
    public class CancelException : Exception
    {
        public CancelException() { }

        public CancelException(string message) : base(message) { }
    }
}
