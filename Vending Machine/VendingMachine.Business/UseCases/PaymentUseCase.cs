using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using VendingMachine.Business.PresentationLayer;

namespace iQuest.VendingMachine.UseCases
{
    public class PaymentUseCase : IPaymentUseCase
    {
        private readonly IBuyView buyView;
        private List<IPaymentAlgorithm> paymentAlgorithms= new List<IPaymentAlgorithm>();

        public IBuyView BuyView => buyView;

        public List<IPaymentAlgorithm> PaymentAlgorithms=> paymentAlgorithms;

        public PaymentUseCase(IBuyView buyView, List<IPaymentAlgorithm> paymentAlgorithms)
        {
            this.buyView = buyView ?? throw new ArgumentException(nameof(buyView));
            this.paymentAlgorithms = paymentAlgorithms ?? throw new ArgumentException(nameof(paymentAlgorithms));
        }

        public void Execute(float price) 
        {
            List<PaymentMethod> paymentMethods = paymentAlgorithms
                .Select(x => new PaymentMethod { id = paymentAlgorithms.IndexOf(x), Name = x.Name }).ToList();
            int selectedPaymentMethodId = buyView.AskForPaymentMethod(paymentMethods);

            IPaymentAlgorithm selectedPaymentMethod = paymentAlgorithms[selectedPaymentMethodId];
            selectedPaymentMethod.Run(price);
        }
    }
}
