using System;
using System.Collections.Generic;
using iQuest.VendingMachine.DataLayer;
using iQuest.VendingMachine.Interfaces;

namespace iQuest.VendingMachine.PresentationLayer
{
    public class ShelfView : DisplayBase,IShelfView
    {
        public void DisplayProducts(IEnumerable<Product> products)
        {
            Console.WriteLine("Products : \n");
            foreach (Product product in products)
            {
                Display(product.ColumnId.ToString(), ConsoleColor.Magenta);
                Display("->", ConsoleColor.Yellow);
                DisplayLine(product.Name, ConsoleColor.Yellow);
                Display("Price ->", ConsoleColor.Green);
                DisplayLine(product.Price.ToString(), ConsoleColor.Gray);
                Display("Left ->", ConsoleColor.Cyan);
                DisplayLine(product.Quantity.ToString(), ConsoleColor.Gray);
            }
        }
    }
}
