using iQuest.VendingMachine.DataLayer;
using iQuest.VendingMachine.Exceptions;
using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.UseCases;
using Moq;
using VendingMachine.Business.PresentationLayer;

namespace BuyUseCaseTests
{
    [TestClass]
    public class BuyUseCaseExecuteTests
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
            mockPaymentUseCase= new Mock<IPaymentUseCase>();
            buyUseCase = new BuyUseCase(mockAuthenticationService.Object, mockProductRepository.Object, mockBuyView.Object, mockPaymentUseCase.Object);
        }

        [TestMethod]
        public void HavingABuyUseCaseInstance_WhenExecuted_ThenItRequestsFromProductRepositoryTheProductWithIdReceivedFromBuyView()
        {
            mockBuyView
                .Setup(x => x.RequestProduct())
                .Returns(101);
            mockProductRepository
                .Setup(x => x.GetByColumn(It.IsAny<int>()))
                .Returns(new Product(1, "unk", 1, 1));

            buyUseCase.Execute();

            mockBuyView.Verify(x => x.RequestProduct(),Times.Once);
            mockProductRepository.Verify(x => x.GetByColumn(101), Times.Once);
        }

        [TestMethod]
        public void HavingABuyUseCaseInstance_WhenExecuted_DecremntTheQuantityOfProduct_ThenDisplayTheProduct()
        {
            var product = new Product(1, "unk", 1, 1);

            mockBuyView
                .Setup(x => x.RequestProduct())
                .Returns(1);
            mockProductRepository
                .Setup(x => x.GetByColumn(It.IsAny<int>()))
                .Returns(product);
          
            buyUseCase.Execute();

            mockProductRepository.Verify(x => x.DecrementQuantity(product), Times.Once);
            mockBuyView.Verify(x => x.DispenseProduct(product.Name), Times.Once);
        }

        [TestMethod]
        public void HavingABuyUseCaseInstance_WhenExecuted_UserMustPayForTheProduct()
        {
            var product = new Product(1, "unk", 1, 1);
            mockBuyView
                .Setup(x => x.RequestProduct())
                .Returns(1);
            mockProductRepository
                .Setup(x => x.GetByColumn(It.IsAny<int>()))
                .Returns(product);
            mockPaymentUseCase
                .Setup(x => x.Execute(1));

            buyUseCase.Execute();

            mockBuyView.Verify(x => x.DispenseProduct(product.Name), Times.Once);
        }

        [TestMethod]
        public void HavingABuyUseCaseInstance_WhenExecuted_ThenItRequestsFromProductRepositoryTheProductWithIdReceivedFromBuyView_ExceptionWhenTheRequestedProductIsNotInTheList()
        {
            var product = new Product(1, "unk", 1, 1);

            mockBuyView
                .Setup(x => x.RequestProduct())
                .Returns(123);

            Assert.ThrowsException<InvalidColumnException>(() =>buyUseCase.Execute());
        }

        [TestMethod]
        public void HavingABuyUseCaseInstance_WhenExecuted_DecremntTheQuantityOfProduct_ThenDisplayTheProduct_ExceptionWhenThereAreNoProductsLeft()
        {
            var product = new Product(1, "unk", 1, 0);

            mockBuyView
                .Setup(x => x.RequestProduct())
                .Returns(1);
            mockProductRepository
                .Setup(x => x.GetByColumn(1))
                .Returns(product);
           
            Assert.ThrowsException<InsufficientStockException>(() => buyUseCase.Execute());
        }
    }
}
