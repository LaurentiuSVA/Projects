using System;
using System.Collections.Generic;
using System.Text;

namespace iQuest.VendingMachine.Exceptions
{
    public class InvalidMoneyException : Exception
    {
        public InvalidMoneyException() { }

        public InvalidMoneyException(string message) : base(message) { }
    }
}
