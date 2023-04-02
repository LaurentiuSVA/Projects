using iQuest.VendingMachine.DataLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace iQuest.VendingMachine.Interfaces
{
    public interface IStockDisplay
    {
        public Product AskForProduct();

        public int AskForQuantity();

        public int AskForColumnId();
    }
}
