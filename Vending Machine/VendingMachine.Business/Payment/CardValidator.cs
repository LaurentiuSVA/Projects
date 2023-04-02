using System;
using System.Collections.Generic;
using System.Text;

namespace iQuest.VendingMachine.Payment
{
    public class CardValidator
    {
        public static bool IsCardNumberValid(string cardNumber)
        {
            int nDigits = cardNumber.Length;
            int sum = 0;
            bool alternate = false;
            for (int i = nDigits - 1; i >= 0; i--)
            {
                int digit = cardNumber[i] - '0';
                if (alternate)
                {
                    digit = digit * 2;
                    if (digit > 9)
                    {
                        digit = digit - 9;
                    }
                    sum += digit;
                }
                else
                {
                    sum += digit;
                }
                alternate = !alternate;
            }
            return (sum % 10 == 0);
        }
    }
}
