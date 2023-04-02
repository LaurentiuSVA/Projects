using iQuest.VendingMachine.DataLayer;
using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.UseCases;
using Moq;

namespace VendingMachine.Test.RemoveProductUseCaseTest
{
    [TestClass]
    public class RemoveProductUseCaseExecuteTest
    {
        [TestMethod]
        public void HavingAnRemoveProductUseCaseInstance_WhenExecuted_RemoveTheSelectedProductFromTheList()
        {
            var mockAuthentification = new Mock<IAuthenticationService>();
            var mockStockDisplay = new Mock<IStockDisplay>();
            var mockProductRepository = new Mock<IProductReposotory>();
            RemoveProductUseCase removeProductUseCase= new RemoveProductUseCase(mockAuthentification.Object, mockProductRepository.Object, mockStockDisplay.Object);
            var product = new Product();
            mockStockDisplay
                .Setup(x => x.AskForColumnId())
                .Returns(product.ColumnId);

            removeProductUseCase.Execute();

            mockProductRepository.Verify(x => x.DeleteProduct(product.ColumnId), Times.Once);
        }
    }
}
