using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.UseCases;
using Moq;

namespace VendingMachine.Test.SupplyUseCaseTest
{
    [TestClass]
    public class SupplyUseCaseConstructorTest
    {
        [TestMethod]
        public void SupplyUseCase_Constructor_SetsFieldsCorrectly()
        {
            var mockAuthentification = new Mock<IAuthenticationService>();
            var mockStockDisplay = new Mock<IStockDisplay>();
            var mockProductRepository = new Mock<IProductReposotory>();
            SupplyUseCase supplyUseCase= new SupplyUseCase(mockAuthentification.Object, mockProductRepository.Object, mockStockDisplay.Object);

            Assert.AreSame(mockAuthentification.Object, supplyUseCase.Authentification);
            Assert.AreSame(mockStockDisplay.Object, supplyUseCase.StockDisplay);
            Assert.AreSame(mockProductRepository.Object, supplyUseCase.ProductRepository);
        }
    }
}
