using iQuest.VendingMachine.Interfaces;
using System;

namespace iQuest.VendingMachine.UseCases
{
    public class RemoveProductUseCase : IUseCase
    {
        IAuthenticationService authentificationService;
        IProductReposotory productRepository;
        IStockDisplay stockDisplay;

        public string Name => "remove product";

        public string Description => "Remove product from list";

        public bool CanExecute => authentificationService.UserIsLoggedIn;

        public IAuthenticationService Authentification => authentificationService;

        public IStockDisplay StockDisplay => stockDisplay;

        public IProductReposotory ProductRepository => productRepository;

        public RemoveProductUseCase(IAuthenticationService authentificationService, IProductReposotory productRepository, IStockDisplay stockDisplay)
        {
            this.authentificationService = authentificationService ?? throw new ArgumentNullException(nameof(authentificationService));
            this.productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            this.stockDisplay = stockDisplay ?? throw new ArgumentNullException(nameof(stockDisplay));
        }

        public void Execute()
        {
            int columnid = stockDisplay.AskForColumnId();
            productRepository.DeleteProduct(columnid);
        }
    }
}
