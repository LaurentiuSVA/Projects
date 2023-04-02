using iQuest.VendingMachine.DataLayer;
using System.Collections.Generic;

namespace iQuest.VendingMachine.Interfaces
{
    public interface IShelfView
    {
        public void DisplayProducts(IEnumerable<Product> products) { }

    }
}
