using iQuest.VendingMachine.Exceptions;
using iQuest.VendingMachine.Interfaces;
using System;

namespace iQuest.VendingMachine.Payment
{
    public class CardPayment : IPaymentAlgorithm
    {
        private readonly ICardPaymentTerminal cardPaymentTerminal;

        public string Name { get; private set; } = "Credit Card";
        
        public CardPayment(ICardPaymentTerminal cardPaymentTerminal)
        {
            this.cardPaymentTerminal = cardPaymentTerminal ?? throw new ArgumentNullException(nameof(cardPaymentTerminal));
        }

        public void Run(float price)
        {
            string cardNumber = cardPaymentTerminal.AskForCardNumber();

            if (!CardValidator.IsCardNumberValid(cardNumber))
            {
                throw new InvalidCardNumberException("Invalid Input");
            }
        }
    }
}
