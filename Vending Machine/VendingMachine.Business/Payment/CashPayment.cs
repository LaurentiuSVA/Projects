using iQuest.VendingMachine.Exceptions;
using iQuest.VendingMachine.Interfaces;
using System;
using System.Threading;

namespace iQuest.VendingMachine.Payment
{
    public class CashPayment : IPaymentAlgorithm
    {
        private readonly ICashPaymentTerminal cashPaymentTerminal;

        public string Name { get; private set; } = "Cash";

        public CashPayment(ICashPaymentTerminal cashPaymentTerminal)
        {
            this.cashPaymentTerminal = cashPaymentTerminal ?? throw new ArgumentNullException(nameof(cashPaymentTerminal));
        }

        public void Run(float price)
        {
            cashPaymentTerminal.CostOfPoduct(price);
            float userMoney = 0;
            try
            {
                userMoney = cashPaymentTerminal.AskForMoney();
                while (userMoney < price)
                {
                    cashPaymentTerminal.InsufficientFunds();
                    userMoney = userMoney + cashPaymentTerminal.AskForMoney();
                }
                float change = userMoney - price;
                if (change > 0)
                {
                    cashPaymentTerminal.GiveBackChange(change);
                }
            }
            catch (InvalidMoneyException e)
            {
                cashPaymentTerminal.GiveBackChange(userMoney);
                throw e;
            }
            catch (CancelException e)
            {
                cashPaymentTerminal.GiveBackChange(userMoney);
                throw e;
            }
        }
    }
}
