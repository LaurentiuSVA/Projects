using iQuest.VendingMachine.Exceptions;
using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using VendingMachine.Business.PresentationLayer;

namespace iQuest.VendingMachine.PresentationLayer
{
    public class BuyView : DisplayBase, IBuyView
    {
        public int RequestProduct()
        {
            string strRegex = @"\D+";
            Regex regex = new Regex(strRegex);

            Console.WriteLine();
            Display("Choose ID: ", ConsoleColor.Cyan);
            string chosenId = Console.ReadLine();
            Console.WriteLine();
            if (String.IsNullOrEmpty(chosenId))
            {
                throw new CancelException("ID can't be empty");
            }
            if (regex.IsMatch(chosenId))
            {
                throw new InvalidColumnException("Invalid input");
            }

            return Int32.Parse(chosenId);
        }

        public void DispenseProduct(string productName)
        {
            Display("Bought ", ConsoleColor.Green);
            DisplayLine("-> " + productName, ConsoleColor.DarkCyan);
        }

        public int AskForPaymentMethod(IEnumerable<PaymentMethod> paymentMethods)
        {
            DisplayLine("Payment Methods: ", ConsoleColor.White);
            int idOfPaymentMethod = 1;

            foreach (var paymentMethod in paymentMethods)
            {
                Console.WriteLine(idOfPaymentMethod + "." + paymentMethod.Name);
                idOfPaymentMethod++;
            }

            Display("Enter the id of payment method: ", ConsoleColor.White);
            int paymentMethodIndex;
            if (!int.TryParse(Console.ReadLine(), out paymentMethodIndex) || paymentMethodIndex < 1 || paymentMethodIndex > paymentMethods.Count())
            {
                throw new CancelException("Invalid input. Please enter a valid id.");
            }
            int paymentMethodId = paymentMethods.ElementAt(paymentMethodIndex - 1).id;

            return paymentMethodId;
        }
    }
}
