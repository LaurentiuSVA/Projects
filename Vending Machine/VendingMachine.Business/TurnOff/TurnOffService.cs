using iQuest.VendingMachine.Interfaces;

namespace iQuest.VendingMachine.AutentificationService
{
    public class TurnOffService : ITurnOffService
    {
        public bool TurnOffWasRequested { get; private set; }

        public void TurnOff()
        {
            TurnOffWasRequested =true;
        }
    }
}

