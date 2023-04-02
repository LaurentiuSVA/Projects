using iQuest.VendingMachine.Exceptions;
using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.Payment;
using Moq;

namespace VendingMachine.Test.PaymentUseCaseTest
{
    [TestClass]
    public class CashPaymentTest
    {
        [TestMethod]
        public void CashPaymnet_ShouldRun_WithValidInput_NotThrowingException()
        {
            var mockCashPaymentTerminal = new Mock<ICashPaymentTerminal>();
            CashPayment cashPayment = new CashPayment(mockCashPaymentTerminal.Object);

            mockCashPaymentTerminal
                .Setup(x => x.AskForMoney())
                .Returns(11.2f);

            cashPayment.Run(11.2f);

            mockCashPaymentTerminal.Verify(x => x.AskForMoney(), Times.Once);
        }

        [TestMethod]
        public void CashPaymnet_ShouldRun_WithValidInput_ShouldReleseTheChange()
        {
            var mockCashPaymentTerminal = new Mock<ICashPaymentTerminal>();
            CashPayment cashPayment = new CashPayment(mockCashPaymentTerminal.Object);

            mockCashPaymentTerminal
                .SetupSequence(x => x.AskForMoney())
                .Returns(1.5f).Returns(2f).Returns(3f);

            cashPayment.Run(5f);

            mockCashPaymentTerminal.Verify(x => x.AskForMoney(), Times.Exactly(3));
            mockCashPaymentTerminal.Verify(x => x.GiveBackChange(1.5f),Times.Once);
        }

        [TestMethod]
        public void CashPayment_WithCancelException_ShouldThrowCancelException()
        {
            var mockCashPaymentTerminal = new Mock<ICashPaymentTerminal>();
            mockCashPaymentTerminal.Setup(x => x.AskForMoney()).Throws(new CancelException());

            CashPayment cashPayment = new CashPayment(mockCashPaymentTerminal.Object);

            Assert.ThrowsException<CancelException>(() => cashPayment.Run(11.2f));
        }
        [TestMethod]
        public void CashPayment_WithInvalidMoneyException_ShouldThrowCancelException()
        {
            var mockCashPaymentTerminal = new Mock<ICashPaymentTerminal>();
            mockCashPaymentTerminal.Setup(x => x.AskForMoney()).Throws(new InvalidMoneyException());

            CashPayment cashPayment = new CashPayment(mockCashPaymentTerminal.Object);

            Assert.ThrowsException<InvalidMoneyException>(() => cashPayment.Run(11.2f));
        }
    }
}
