using iQuest.VendingMachine.DataLayer;
using iQuest.VendingMachine.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace iQuest.VendingMachine.PresentationLayer
{
    public class StockDisplay : DisplayBase, IStockDisplay
    {
        public Product AskForProduct()
        {
            Product product = new Product();
            DisplayLine("Enter product details:", ConsoleColor.White);
            DisplayLine("Id: ", ConsoleColor.Cyan);
            product.ColumnId = int.Parse(Console.ReadLine());
            DisplayLine("Name: ", ConsoleColor.Cyan);
            product.Name = Console.ReadLine();
            DisplayLine("Price: ", ConsoleColor.Cyan);
            product.Price = float.Parse(Console.ReadLine());
            DisplayLine("Quantity: ", ConsoleColor.Cyan);
            product.Quantity = int.Parse(Console.ReadLine());
            return product;
        }

        public int AskForQuantity()
        {
            DisplayLine("Enter the quantity of the product you want to add: ", ConsoleColor.Cyan);
            return int.Parse(Console.ReadLine());
        }

        public int AskForColumnId()
        {
            DisplayLine("Enter the column ID of the product: ", ConsoleColor.Cyan);
            return int.Parse(Console.ReadLine());
        }
    }
}
