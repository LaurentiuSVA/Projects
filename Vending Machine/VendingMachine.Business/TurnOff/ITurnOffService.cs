
namespace iQuest.VendingMachine.Interfaces
{
    public interface ITurnOffService
    {
        public bool TurnOffWasRequested { get; }
        public void TurnOff();

    }
}
