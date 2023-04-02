using iQuest.VendingMachine.DataLayer;
using iQuest.VendingMachine.Interfaces;
using System;

namespace iQuest.VendingMachine.UseCases
{
    public class AddProductUseCase : IUseCase
    {
        private readonly IAuthenticationService authentificationService;
        private readonly IProductReposotory productRepository;
        private readonly IStockDisplay stockDisplay;

        public string Name => "add product";

        public string Description => "Add a new product to the existing ones";

        public bool CanExecute => authentificationService.UserIsLoggedIn;

        public IAuthenticationService Authentification => authentificationService;

        public IStockDisplay StockDisplay => stockDisplay;

        public IProductReposotory ProductRepository => productRepository;

        public AddProductUseCase(IAuthenticationService authentificationService, IProductReposotory productRepository, IStockDisplay stockDisplay)
        {
            this.authentificationService = authentificationService ?? throw new ArgumentNullException(nameof(authentificationService));
            this.productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            this.stockDisplay = stockDisplay ?? throw new ArgumentNullException(nameof(stockDisplay));
        }

        public void Execute()
        {
            Product product = stockDisplay.AskForProduct();
            productRepository.AddProduct(product);
        }
    }
}
