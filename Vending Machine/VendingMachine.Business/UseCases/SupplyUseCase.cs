using iQuest.VendingMachine.Interfaces;
using System;

namespace iQuest.VendingMachine.UseCases
{
    public class SupplyUseCase : IUseCase
    {
        IAuthenticationService authentificationService;
        IProductReposotory productRepository;
        IStockDisplay stockDisplay;

        public string Name => "supply product";

        public string Description => "Add new existing products";

        public bool CanExecute => authentificationService.UserIsLoggedIn;

        public IAuthenticationService Authentification => authentificationService;

        public IStockDisplay StockDisplay => stockDisplay;

        public IProductReposotory ProductRepository => productRepository;

        public SupplyUseCase(IAuthenticationService authentificationService, IProductReposotory productRepository, IStockDisplay stockDisplay)
        {
            this.authentificationService = authentificationService ?? throw new ArgumentNullException(nameof(authentificationService));
            this.productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            this.stockDisplay = stockDisplay ?? throw new ArgumentNullException(nameof(stockDisplay));
        }

        public void Execute()
        {
            int columnid = stockDisplay.AskForColumnId();
            int newQuantity = stockDisplay.AskForQuantity();
            productRepository.Update(columnid, newQuantity);
        }
    }
}
