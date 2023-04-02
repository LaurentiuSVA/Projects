using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.UseCases;
using Moq;
using VendingMachine.Business.PresentationLayer;

namespace BuyUseCaseTests
{
    [TestClass]
    public class BuyUseCaseCanExecuteTests
    {
        private Mock<IProductReposotory> mockProductRepository;
        private Mock<IBuyView> mockBuyView;
        private Mock<IAuthenticationService> mockAuthenticationService;
        private BuyUseCase buyUseCase;
        private Mock<IPaymentUseCase> mockPaymentUseCase;

        [TestInitialize]
        public void SetUp()
        {
            mockProductRepository = new Mock<IProductReposotory>();
            mockBuyView = new Mock<IBuyView>();
            mockAuthenticationService = new Mock<IAuthenticationService>();
            mockPaymentUseCase = new Mock<IPaymentUseCase>();
            buyUseCase = new BuyUseCase(mockAuthenticationService.Object, mockProductRepository.Object, mockBuyView.Object, mockPaymentUseCase.Object);
        }

        [TestMethod]
        public void HavingNoAdminLoggedIn_CanExecuteIsTrue()
        {
            mockAuthenticationService
            .Setup(x => x.UserIsLoggedIn)
                .Returns(false);

            Assert.IsTrue(buyUseCase.CanExecute);
        }

        [TestMethod]
        public void HavingAdminLoggedIn_CanExecuteIsFalse()
        {

            mockAuthenticationService
                .Setup(x => x.UserIsLoggedIn)
                .Returns(true);

            Assert.IsFalse(buyUseCase.CanExecute);
        }
    }
}
