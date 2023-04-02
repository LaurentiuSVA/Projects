using iQuest.VendingMachine.DataLayer;
using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.UseCases;
using Moq;

namespace VendingMachine.Test.SupplyUseCaseTest
{
    [TestClass]
    public class SupplyUseCaseExecuteTest
    {
        [TestMethod]
        public void HavingAnRemoveProductUseCaseInstance_WhenExecuted_RemoveTheSelectedProductFromTheList()
        {
            var mockAuthentification = new Mock<IAuthenticationService>();
            var mockStockDisplay = new Mock<IStockDisplay>();
            var mockProductRepository = new Mock<IProductReposotory>();
            SupplyUseCase supplyUseCase= new SupplyUseCase(mockAuthentification.Object, mockProductRepository.Object, mockStockDisplay.Object);
            var product = new Product();
            mockStockDisplay
                .Setup(x => x.AskForColumnId())
                .Returns(product.ColumnId);
            
            mockStockDisplay 
                .Setup(x => x.AskForQuantity())
                .Returns(product.Quantity);

            supplyUseCase.Execute();

            mockProductRepository.Verify(x => x.Update(product.ColumnId,product.Quantity), Times.Once);
        }
    }
}
