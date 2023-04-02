using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.UseCases;
using Moq;

namespace LogoutUseCaseTest
{
    [TestClass]
    public class LogoutUseCaseCanExecuteTest
    {
        [TestMethod]
        public void HavingNoAdminLoggedIn_CanExecuteIsFalse()
        {
            var mockMainDisplay = new Mock<IMainDisplay>();
            var mockAuthentification = new Mock<IAuthenticationService>();
            mockAuthentification
                .Setup(x => x.UserIsLoggedIn)
                .Returns(false);
            LogoutUseCase logoutUseCase = new LogoutUseCase(mockAuthentification.Object);

            logoutUseCase.Execute();

            Assert.IsFalse(logoutUseCase.CanExecute);
        }
        [TestMethod]
        public void HavingAdminLoggedIn_CanExecuteIsTrue()
        {
            var mockMainDisplay = new Mock<IMainDisplay>();
            var mockAuthentification = new Mock<IAuthenticationService>();
            mockAuthentification
                .Setup(x => x.UserIsLoggedIn)
                .Returns(true);
            LogoutUseCase logoutUseCase = new LogoutUseCase(mockAuthentification.Object);

            logoutUseCase.Execute();

            Assert.IsTrue(logoutUseCase.CanExecute);
        }

    }
}
