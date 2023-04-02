using iQuest.VendingMachine.DataLayer;
using iQuest.VendingMachine.Exceptions;
using iQuest.VendingMachine.Interfaces;
using System;
using VendingMachine.Business.PresentationLayer;

namespace iQuest.VendingMachine.UseCases
{
    public class BuyUseCase : IUseCase
    {
        private readonly IAuthenticationService autentification;
        private readonly IProductReposotory productRepository;
        private readonly IBuyView buyView;
        private readonly IPaymentUseCase paymentUseCase;
        public string Name => "buy";

        public string Description => "Buy a product";

        public bool CanExecute => !autentification.UserIsLoggedIn;
        public IAuthenticationService Authentification => autentification;

        public IBuyView BuyView => buyView;

        public IProductReposotory ProductRepository => productRepository;


        public BuyUseCase(IAuthenticationService autentification, IProductReposotory productRepository, IBuyView buyView, IPaymentUseCase paymentUseCase)
        {
            this.autentification = autentification ?? throw new ArgumentNullException(nameof(autentification));
            this.productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            this.buyView = buyView ?? throw new ArgumentNullException(nameof(buyView));
            this.paymentUseCase = paymentUseCase ?? throw new ArgumentNullException(nameof(paymentUseCase));

        }

        public void Execute()
        {
            int columnID = buyView.RequestProduct();
            Product product = productRepository.GetByColumn(columnID);

            if (product == null)
            {
                throw new InvalidColumnException("The element selected was not found !!!!");
            }

            if (product.Quantity > 0)
            {
                float amount = product.Price;
                paymentUseCase.Execute(amount);
                productRepository.DecrementQuantity(product);
                buyView.DispenseProduct(product.Name);
            }
            else
            {
                throw new InsufficientStockException("No more products!");
            }
        }
    }
}


