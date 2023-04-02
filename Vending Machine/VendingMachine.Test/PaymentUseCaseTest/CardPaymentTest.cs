using iQuest.VendingMachine.Exceptions;
using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.Payment;
using Moq;

namespace VendingMachine.Test.PaymentUseCaseTest
{
    [TestClass]
    public class CardPaymentTest
    {
        [TestMethod]
        public void CardPayment_WhenExecuted_ShouldAskForCardNumber()
        {
            var mockCardPaymentTerminal = new Mock<ICardPaymentTerminal>();
            mockCardPaymentTerminal
                .Setup(x => x.AskForCardNumber())
                .Returns("79927398713");

            CardPayment cardPayment = new CardPayment(mockCardPaymentTerminal.Object);

            cardPayment.Run(11.2f);

            mockCardPaymentTerminal.Verify(x => x.AskForCardNumber(), Times.Once);
        }

        [TestMethod]
        public void AskForCardNumber_EmptyCardNumber_ThrowsCancelException()
        {
            var mockCardPaymentTerminal = new Mock<ICardPaymentTerminal>();
            mockCardPaymentTerminal.Setup(x => x.AskForCardNumber()).Throws(new CancelException());

            CardPayment cardPayment = new CardPayment(mockCardPaymentTerminal.Object);

            Assert.ThrowsException<CancelException>(() => cardPayment.Run(11.2f));
        }

        [TestMethod]
        public void AskForCardNumber_InvalidCardNumber_ThrowsInvalidCardNumberException()
        {
            var mockCardPaymentTerminal = new Mock<ICardPaymentTerminal>();
            mockCardPaymentTerminal.Setup(x => x.AskForCardNumber()).Throws(new InvalidCardNumberException());

            CardPayment cardPayment = new CardPayment(mockCardPaymentTerminal.Object);

            Assert.ThrowsException<InvalidCardNumberException>(() => cardPayment.Run(11.2f));
        }
    }
}
