using iQuest.VendingMachine.Interfaces;
using System;

namespace iQuest.VendingMachine.UseCases
{
    public class LogoutUseCase : IUseCase
    {
        private readonly IAuthenticationService authentification;

        public string Name => "logout";

        public string Description => "Restrict access to administration buttons.";

        public bool CanExecute => authentification.UserIsLoggedIn;

        public IAuthenticationService Authentification => authentification;

        public LogoutUseCase(IAuthenticationService authentification)
        {
            this.authentification = authentification ?? throw new ArgumentNullException(nameof(authentification));
        }

        public void Execute()
        {
            authentification.Logout();
        }
    }
}