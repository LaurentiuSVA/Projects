
namespace iQuest.VendingMachine.Interfaces
{
    public interface ICashPaymentTerminal
    {
        public float AskForMoney();

        public void GiveBackChange(float change);

        public void InsufficientFunds();

        public void CostOfPoduct(float price);
    }
}
