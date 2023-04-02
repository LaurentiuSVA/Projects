
namespace iQuest.VendingMachine.DataLayer
{
    public class Product
    {
        public int ColumnId { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }

        public Product() { }

        public Product(int columnid, string name, float price, int quantity)
        {
            ColumnId = columnid;
            Name = name;
            Price = price;
            Quantity = quantity;
        }
    }
}
