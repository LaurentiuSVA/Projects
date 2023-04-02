using iQuest.VendingMachine.DataLayer;
using iQuest.VendingMachine.Interfaces;
using System;
using System.Collections.Generic;

namespace iQuest.VendingMachine.UseCases
{
    public class LookUseCase : IUseCase
    {
        private readonly IProductReposotory productRepository;
        private readonly IShelfView shelfView;

        public string Name => "view";

        public string Description => "This command show the products :";

        public IProductReposotory ProductRepository => productRepository;

        public IShelfView ShelfView => shelfView;

        public bool CanExecute => true;

        public LookUseCase(IProductReposotory productRepository, IShelfView shelfView)
        {
            this.productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            this.shelfView = shelfView ?? throw new ArgumentNullException(nameof(shelfView));
        }
        public void Execute()
        {
            IEnumerable<Product> products = productRepository.GetAll();
            shelfView.DisplayProducts(products);
        }
    }
}
