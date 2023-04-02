using iQuest.VendingMachine.Exceptions;
using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.PresentationLayer;
using System;

namespace iQuest.VendingMachine.Payment
{
    public class CashPaymentTerminal : DisplayBase, ICashPaymentTerminal
    {
        public float AskForMoney()
        {
            DisplayLine("Insert money: ", ConsoleColor.DarkYellow);
            string money = Console.ReadLine();

            if (String.IsNullOrEmpty(money))
            {
                throw new CancelException("You didn't add any more money");
            }
            if (!float.TryParse(money, out float moneyValue))
            {
                throw new InvalidMoneyException("Invalid input for money");
            }

            return moneyValue;
        }

        public void GiveBackChange(float change)
        {
            DisplayLine("Returning money: $" + change, ConsoleColor.Yellow);
        }

        public void InsufficientFunds()
        {
            DisplayLine("Insufficient funds: ", ConsoleColor.Red);
            DisplayLine("Please add more money: \n", ConsoleColor.Red);
        }

        public void CostOfPoduct(float price)
        {
            DisplayLine("Processing cash payment for $" + price, ConsoleColor.Cyan);
        }
    }
}
