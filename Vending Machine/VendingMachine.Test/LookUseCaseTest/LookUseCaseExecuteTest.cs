using iQuest.VendingMachine.DataLayer;
using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.UseCases;
using Moq;

namespace LookUseCaseTest
{
    [TestClass]
    public class LookUseCaseExecuteTest
    {
        [TestMethod]
        public void HavingALookUseCaseInstance_WhenExecuted_GetAll_ShouldReturnExpectedResult()
        {
            var mockProductRepository = new Mock<IProductReposotory>();
            var mockShelfView = new Mock<IShelfView>();
            var lookUseCase = new LookUseCase(mockProductRepository.Object, mockShelfView.Object);
            mockProductRepository
                .Setup(x => x.GetAll())
                .Returns(new List<Product>());
            mockShelfView
                .Setup(x => x.DisplayProducts(new List<Product>()));

            lookUseCase.Execute();

            mockProductRepository.Verify(x => x.GetAll(), Times.Once);
            mockShelfView.Verify(x => x.DisplayProducts((new List<Product>())), Times.Once);
        }
    }
}
