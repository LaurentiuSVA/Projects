using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.UseCases;
using Moq;
using VendingMachine.Business.PresentationLayer;

namespace VendingMachine.Test.PaymentUseCaseTest
{
    [TestClass]
    public class PaymentUseCaseConstructor
    {
        [TestMethod]
        public void PaymentUseCase_Constructor_SetsFieldsCorrectly()
        {
            var mockBuyView = new Mock<IBuyView>();
            var mockPaymentAlgorithms = new List<IPaymentAlgorithm>();
            PaymentUseCase paymentUseCase= new PaymentUseCase(mockBuyView.Object,mockPaymentAlgorithms);

            Assert.AreSame(mockBuyView.Object, paymentUseCase.BuyView);
            Assert.AreSame(mockPaymentAlgorithms, paymentUseCase.PaymentAlgorithms);
        }
    }
}
