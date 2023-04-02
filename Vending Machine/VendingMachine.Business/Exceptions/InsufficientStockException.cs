using System;

namespace iQuest.VendingMachine.Exceptions
{
    public class InsufficientStockException : Exception
    {
        public InsufficientStockException() { }

        public InsufficientStockException(string message) : base(message) { }
    }
}
