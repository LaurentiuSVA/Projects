using iQuest.VendingMachine.Exceptions;
using iQuest.VendingMachine.Interfaces;

namespace iQuest.VendingMachine.AutentificationService
{
    public class AuthenticationService : IAuthenticationService
    {
        public bool UserIsLoggedIn { get; private set; }

        public bool Login(string passwordUserInput)
        {
            if (passwordUserInput == "1234")
                return UserIsLoggedIn=true;
            else
                throw new InvalidPasswordException("Invalid Password");
        }

        public bool Logout()
        {
            return UserIsLoggedIn = false;
        }
    }
}
