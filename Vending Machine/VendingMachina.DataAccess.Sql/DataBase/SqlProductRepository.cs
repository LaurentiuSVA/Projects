using Dapper;
using iQuest.VendingMachine.DataLayer;
using iQuest.VendingMachine.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace iQuest.VendingMachine.Data
{
    public class SqlProductRepository : IProductReposotory
    {
        private readonly string connectionString;

        public SqlProductRepository(string connectionString)
        {
            this.connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
            if (IsDatabaseEmpty())
            {
                InitializeDatabase();
            }
        }

        private void InitializeDatabase()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var products = new List<Product>
                {
                    new Product { ColumnId = 1, Name = "Tea", Price = 3, Quantity = 30},
                    new Product { ColumnId = 2, Name = "Coffee", Price = 4, Quantity = 1},
                    new Product { ColumnId = 3, Name = "Chocolate", Price = 5, Quantity = 0},
                    new Product { ColumnId = 12, Name = "Croissant", Price = 7, Quantity = 21}
                };

                var insertSql = "INSERT INTO Products (ColumnId, Name, Price, Quantity) VALUES (@ColumnId, @Name, @Price, @Quantity)";
                connection.Execute(insertSql, products);
            }
        }

        private bool IsDatabaseEmpty()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                int count = connection.QueryFirst<int>("SELECT COUNT(*) FROM Products");
                return count == 0;
            }
        }

        public IEnumerable<Product> GetAll()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query<Product>("SELECT * FROM Products");
            }
        }

        public Product GetByColumn(int columnId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var product = connection.QueryFirstOrDefault<Product>("SELECT TOP 1 * FROM Products WHERE ColumnId=@ColumnId", new { ColumnId = columnId });
                return product;
            }
        }

        public void DecrementQuantity(Product product)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                connection.Execute("UPDATE Products SET Quantity=Quantity-1 WHERE ColumnId=@ColumnId", new { ColumnId = product.ColumnId });
            }
        }

        public void Update(int columnid, int newQuantity)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                connection.Execute("UPDATE Products SET Quantity=Quantity+@NewQuantity WHERE ColumnId=@ColumnId", new { ColumnId = columnid, NewQuantity = newQuantity });
            }
        }

        public void AddProduct(Product product)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var query = "INSERT INTO Products (ColumnId, Name, Price, Quantity) VALUES (@ColumnId, @Name, @Price, @Quantity)";
                connection.Execute(query, product);
            }
        }

        public void DeleteProduct(int columnId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var query = "DELETE FROM Products WHERE ColumnId = @ColumnId";
                connection.Execute(query, new { ColumnId = columnId });
            }
        }
    }
}
