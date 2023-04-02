using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.UseCases;
using Moq;

namespace VendingMachine.Test.RemoveProductUseCaseTest
{
    [TestClass]
    public class RemoveProductUseCaseCanExecuteTest
    {
        [TestMethod]
        public void HavingNoAdminLoggedIn_CanExecuteIsFalse()
        {
            var mockAuthentification = new Mock<IAuthenticationService>();
            var mockStockDisplay = new Mock<IStockDisplay>();
            var mockProductRepository = new Mock<IProductReposotory>();
            mockAuthentification
                .Setup(x => x.UserIsLoggedIn)
                .Returns(false);
            RemoveProductUseCase removeProductUseCase= new RemoveProductUseCase(mockAuthentification.Object, mockProductRepository.Object, mockStockDisplay.Object);

            removeProductUseCase.Execute();

            Assert.IsFalse(removeProductUseCase.CanExecute);
        }

        [TestMethod]
        public void HavingAdminLoggedIn_CanExecuteIsTrue()
        {
            var mockAuthentification = new Mock<IAuthenticationService>();
            var mockStockDisplay = new Mock<IStockDisplay>();
            var mockProductRepository = new Mock<IProductReposotory>();
            mockAuthentification
                .Setup(x => x.UserIsLoggedIn)
                .Returns(true);
            RemoveProductUseCase removeProductUseCase= new RemoveProductUseCase(mockAuthentification.Object, mockProductRepository.Object, mockStockDisplay.Object);

            removeProductUseCase.Execute();

            Assert.IsTrue(removeProductUseCase.CanExecute);
        }
    }
}
