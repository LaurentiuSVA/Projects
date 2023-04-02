using System;
using iQuest.VendingMachine.Interfaces;

namespace iQuest.VendingMachine.UseCases
{
    public class LoginUseCase : IUseCase
    {
        private readonly IAuthenticationService authentification;
        private readonly IMainDisplay mainDisplay;

        public string Name => "login";

        public string Description => "Get access to administration buttons.";

        public bool CanExecute => !authentification.UserIsLoggedIn;

        public IAuthenticationService Authentification => authentification;

        public IMainDisplay MainDisplay => mainDisplay;

        public LoginUseCase(IAuthenticationService autentification, IMainDisplay mainDisplay)
        {
            this.authentification = autentification ?? throw new ArgumentNullException(nameof(autentification));
            this.mainDisplay = mainDisplay ?? throw new ArgumentNullException(nameof(mainDisplay));
        }

        public void Execute()
        {
            string passwordUserInput = mainDisplay.AskForPassword();
            authentification.Login(passwordUserInput);
        }
    }
}