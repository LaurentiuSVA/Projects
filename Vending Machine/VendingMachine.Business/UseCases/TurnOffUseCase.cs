using iQuest.VendingMachine.Interfaces;

namespace iQuest.VendingMachine.UseCases
{
    public class TurnOffUseCase : IUseCase
    {
        private readonly ITurnOffService turnOffService;
        private readonly IAuthenticationService authentificationService;

        public string Name => "exit";

        public string Description => "Go to live your life.";

        public bool CanExecute => authentificationService.UserIsLoggedIn;

        public IAuthenticationService AuthentificationService => authentificationService;

        public ITurnOffService TurnOff => turnOffService;

        public TurnOffUseCase(ITurnOffService turnOffService, IAuthenticationService authentificationService)
        {
            this.turnOffService = turnOffService;
            this.authentificationService = authentificationService;
        }

        public void Execute()
        {
            turnOffService.TurnOff();
        }
    }
}