using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.UseCases;
using Moq;

namespace LogoutUseCaseTest
{
    [TestClass]
    public class LogoutUseCaseExecuteTest
    {
        [TestMethod]
        public void HavingNoAdminLoggedIn_CanExecuteIsFalse()
        {
            var mockMainDisplay = new Mock<IMainDisplay>();
            var mockAuthentification = new Mock<IAuthenticationService>();
            mockAuthentification
                .Setup(x => x.Logout());
            LogoutUseCase logoutUseCase = new LogoutUseCase(mockAuthentification.Object);

            logoutUseCase.Execute();

            mockAuthentification.Verify(x => x.Logout(), Times.Once);
        }
    }
}
