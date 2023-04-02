using iQuest.VendingMachine.Payment;
using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine.Business.PresentationLayer
{
    public interface IBuyView
    {
        public int RequestProduct();
        public void DispenseProduct(string productName);
        public int AskForPaymentMethod(IEnumerable<PaymentMethod> paymentMethods);
    }
}
