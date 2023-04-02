using iQuest.VendingMachine.Exceptions;
using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.PresentationLayer;
using System;

namespace iQuest.VendingMachine.Payment
{
    public class CardPaymentTerminal : DisplayBase, ICardPaymentTerminal
    {
        public string AskForCardNumber()
        {
            DisplayLine("Insert card number: ", ConsoleColor.DarkBlue);
            string cardNumber = Console.ReadLine();

            if (cardNumber == string.Empty)
            {
                throw new CancelException("Card number is empty");
            }
            DisplayLine("Processing card paymenth with card number: " + cardNumber, ConsoleColor.DarkYellow);

            return cardNumber;
        }
    }
}
