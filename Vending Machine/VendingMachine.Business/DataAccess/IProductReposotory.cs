using iQuest.VendingMachine.DataLayer;
using System.Collections.Generic;

namespace iQuest.VendingMachine.Interfaces
{
    public interface IProductReposotory
    {
        public IEnumerable<Product> GetAll();

        public Product GetByColumn(int columnID);

        public void DecrementQuantity(Product product);

        public void AddProduct(Product product);

        public void DeleteProduct(int columnId);

        public void Update(int columnid, int newQuantity);
    }
}
