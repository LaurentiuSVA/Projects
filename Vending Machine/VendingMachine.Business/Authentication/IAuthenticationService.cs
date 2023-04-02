
namespace iQuest.VendingMachine.Interfaces
{
    public interface IAuthenticationService
    {        
        public bool Login(string passwordUserInput);

        public bool UserIsLoggedIn { get; }

        public bool Logout();

    }
}
