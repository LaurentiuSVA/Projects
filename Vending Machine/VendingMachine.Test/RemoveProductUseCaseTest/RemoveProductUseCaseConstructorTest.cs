using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.UseCases;
using Moq;

namespace VendingMachine.Test.RemoveProductUseCaseTest
{
    [TestClass]
    public class RemoveProductUseCaseConstructorTest
    {
        [TestMethod]
        public void AddProductUseCase_Constructor_SetsFieldsCorrectly()
        {
            var mockAuthentification = new Mock<IAuthenticationService>();
            var mockStockDisplay = new Mock<IStockDisplay>();
            var mockProductRepository = new Mock<IProductReposotory>();
            RemoveProductUseCase removeProductUseCase= new RemoveProductUseCase(mockAuthentification.Object, mockProductRepository.Object, mockStockDisplay.Object);

            Assert.AreSame(mockAuthentification.Object, removeProductUseCase.Authentification);
            Assert.AreSame(mockStockDisplay.Object, removeProductUseCase.StockDisplay);
            Assert.AreSame(mockProductRepository.Object, removeProductUseCase.ProductRepository);
        }
    }
}
