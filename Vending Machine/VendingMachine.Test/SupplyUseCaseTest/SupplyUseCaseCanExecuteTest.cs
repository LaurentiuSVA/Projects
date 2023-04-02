using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.UseCases;
using Moq;

namespace VendingMachine.Test.SupplyUseCaseTest
{
    [TestClass]
    public class SupplyUseCaseCanExecuteTest
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
            SupplyUseCase supplyUseCase = new SupplyUseCase(mockAuthentification.Object, mockProductRepository.Object, mockStockDisplay.Object);

            supplyUseCase.Execute();

            Assert.IsFalse(supplyUseCase.CanExecute);
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
            SupplyUseCase supplyUseCase= new SupplyUseCase(mockAuthentification.Object, mockProductRepository.Object, mockStockDisplay.Object);

            supplyUseCase.Execute();

            Assert.IsTrue(supplyUseCase.CanExecute);
        }
    }
}
