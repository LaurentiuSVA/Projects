using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.UseCases;
using Moq;

namespace LookUseCaseTest
{
    [TestClass]
    public class LookUseCaseCanExecuteTest
    {
        [TestMethod]
        public void HavingNoAdmin_OrHavinngAdmin_LoggedIn_CanExecuteIsTrue()
        {
            var mockProductRepository = new Mock<IProductReposotory>();
            var mockShelfView = new Mock<IShelfView>();
            LookUseCase lookUseCase = new LookUseCase(mockProductRepository.Object, mockShelfView.Object);

            Assert.IsTrue(lookUseCase.CanExecute);
        }
    }
}