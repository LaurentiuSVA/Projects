using iQuest.VendingMachine.DataLayer;
using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.UseCases;
using Moq;

namespace VendingMachine.Test.AddProductUseCaseTest
{
    [TestClass]
    public class AddProductUseCaseExecuteTest
    {
        [TestMethod]
        public void HavingAnAddProductUseCaseInstance_WhenExecuted_AddANewProductToTheExistingOnes()
        {
            var mockAuthentification = new Mock<IAuthenticationService>();
            var mockStockDisplay = new Mock<IStockDisplay>();
            var mockProductRepository = new Mock<IProductReposotory>();
            AddProductUseCase addProductUseCase = new AddProductUseCase(mockAuthentification.Object, mockProductRepository.Object, mockStockDisplay.Object);
            var product = new Product();
            mockStockDisplay
                .Setup(x => x.AskForProduct())
                .Returns(product);

            addProductUseCase.Execute();

            mockProductRepository.Verify(x => x.AddProduct(product), Times.Once);
        }
    }
}
