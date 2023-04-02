using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.UseCases;
using Moq;
using VendingMachine.Business.PresentationLayer;

namespace BuyUseCaseTests
{
    [TestClass]
    public class BuyUseCaseConstructorTest
    {
        [TestMethod]
        public void BuyUseCase_Constructor_SetsFieldsCorrectly()
        {
            var mockAuthentification = new Mock<IAuthenticationService>();
            var mockBuyView = new Mock<IBuyView>();
            var mockProductRepository = new Mock<IProductReposotory>();
            var mockPaymentUsecase = new Mock<IPaymentUseCase>();
            BuyUseCase buyUseCase = new BuyUseCase(mockAuthentification.Object, mockProductRepository.Object, mockBuyView.Object, mockPaymentUsecase.Object);

            Assert.AreSame(mockAuthentification.Object, buyUseCase.Authentification);
            Assert.AreSame(mockBuyView.Object, buyUseCase.BuyView);
            Assert.AreSame(mockProductRepository.Object, buyUseCase.ProductRepository);
        }
    }
}
