using iQuest.VendingMachine.Interfaces;
using System.Collections.Generic;

namespace iQuest.VendingMachine.DataLayer
{
    public class InMemoryProductRepository : IProductReposotory
    {

        private static List<Product> products = new List<Product>();

        public InMemoryProductRepository()
        {
            products.Add(new Product(1, "Tea", 3, 30));
            products.Add(new Product(2, "Coffee", 4, 1));
            products.Add(new Product(3, "Chocolate", 5, 0));
            products.Add(new Product(12, "Croissant", 7, 21));
        }

        public IEnumerable<Product> GetAll()
        {
            return products;
        }

        public Product GetByColumn(int columnID)
        {
            return products.Find(product => product.ColumnId == columnID);
        }

        public void DecrementQuantity(Product product)
        {
            product.Quantity--;
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public void DeleteProduct(int columnId)
        {
            products.RemoveAt(columnId);
        }

        public void Update(int columnid, int newQuantity)
        {
            Product product= products.Find(product => product.ColumnId == columnid);
            if(product != null) 
            {
                product.Quantity = newQuantity;
                products[products.IndexOf(product)]=product;
            }
        }
    }
}
