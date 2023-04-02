using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.UseCases;
using Moq;

namespace LookUseCaseTest
{
    [TestClass]
    public class LookUseCaseConstructor
    {
        [TestMethod]
        public void LookUseCase_Constructor_SetsFieldsCorrectly()
        {
            var mockProductRepository = new Mock<IProductReposotory>();
            var mockShelView = new Mock<IShelfView>();
            var lookUseCase = new LookUseCase(mockProductRepository.Object, mockShelView.Object);

            Assert.AreSame(mockProductRepository.Object, lookUseCase.ProductRepository);
            Assert.AreSame(mockShelView.Object, lookUseCase.ShelfView);
        }
    }
}
