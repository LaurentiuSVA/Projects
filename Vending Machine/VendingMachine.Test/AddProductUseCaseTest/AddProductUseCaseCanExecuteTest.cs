using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.UseCases;
using Moq;

namespace VendingMachine.Test.AddProductUseCaseTest
{
    [TestClass]
    public class AddProductUseCaseCanExecuteTest
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
            AddProductUseCase addProductUseCase = new AddProductUseCase(mockAuthentification.Object, mockProductRepository.Object, mockStockDisplay.Object);

            addProductUseCase.Execute();

            Assert.IsFalse(addProductUseCase.CanExecute);
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
            AddProductUseCase addProductUseCase = new AddProductUseCase(mockAuthentification.Object, mockProductRepository.Object, mockStockDisplay.Object);

            addProductUseCase.Execute();

            Assert.IsTrue(addProductUseCase.CanExecute);
        }
    }
}
