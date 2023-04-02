
namespace iQuest.VendingMachine.Interfaces
{
    public interface IPaymentAlgorithm
    {
        string Name { get; }

        public void Run(float price);
    }
}
