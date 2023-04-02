using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.UseCases;
using Moq;

namespace VendingMachine.Test.AddProductUseCaseTest
{
    [TestClass]
    public class AddProductUseCaseConstructorTest
    {
        [TestMethod]
        public void RemoveProductUseCase_Constructor_SetsFieldsCorrectly()
        {
            var mockAuthentification = new Mock<IAuthenticationService>();
            var mockStockDisplay = new Mock<IStockDisplay>();
            var mockProductRepository = new Mock<IProductReposotory>();
            AddProductUseCase addProductUseCase= new AddProductUseCase(mockAuthentification.Object, mockProductRepository.Object, mockStockDisplay.Object);

            Assert.AreSame(mockAuthentification.Object, addProductUseCase.Authentification);
            Assert.AreSame(mockStockDisplay.Object, addProductUseCase.StockDisplay);
            Assert.AreSame(mockProductRepository.Object, addProductUseCase.ProductRepository);
        }
    }
}
