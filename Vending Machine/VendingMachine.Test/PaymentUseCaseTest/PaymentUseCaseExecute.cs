using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.Payment;
using iQuest.VendingMachine.UseCases;
using Moq;
using VendingMachine.Business.PresentationLayer;

namespace VendingMachine.Test.PaymentUseCaseTest
{
    [TestClass]
    public class PaymentUseCaseExecute
    {
        private PaymentUseCase paymentUseCase;
        private List<IPaymentAlgorithm> paymentAlgorithms;
        private Mock<IBuyView> mockBuyView;
        private Mock<IPaymentAlgorithm> mockPaymentAlgorithm;
        [TestInitialize]
        public void Setup()
        {
            mockPaymentAlgorithm = new Mock<IPaymentAlgorithm>();
            mockBuyView = new Mock<IBuyView>();

            paymentAlgorithms = new List<IPaymentAlgorithm>
            {
                mockPaymentAlgorithm.Object,
            };
            paymentUseCase = new PaymentUseCase(mockBuyView.Object, paymentAlgorithms);
        }

        [TestMethod]
        public void HavingAPaymentUseCaseInstance_WhenExecute_ShouldRunSelectedPaymentMethod()
        {
            mockBuyView.Setup(x => x.AskForPaymentMethod(It.IsAny<List<PaymentMethod>>()))
                .Returns(0);

            mockPaymentAlgorithm.Setup(x => x.Run(11.2f));

            paymentUseCase.Execute(11.2f);

            mockPaymentAlgorithm.Verify(x => x.Run(11.2f), Times.Once());
        }
    }
}
