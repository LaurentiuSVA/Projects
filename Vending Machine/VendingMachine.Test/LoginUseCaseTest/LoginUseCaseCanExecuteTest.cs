
using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.UseCases;
using Moq;

namespace LoginUseCaseTest
{
    [TestClass]
    public class LoginUseCaseCanExecuteTest
    {
        [TestMethod]
        public void HavingNoAdminLoggedIn_CanExecuteIsTrue()
        {
            var mockMainDisplay = new Mock<IMainDisplay>();
            var mockAuthentification = new Mock<IAuthenticationService>();
            mockAuthentification
                .Setup(x => x.UserIsLoggedIn)
                .Returns(false);

            LoginUseCase loginUseCase = new LoginUseCase(mockAuthentification.Object, mockMainDisplay.Object);
            loginUseCase.Execute();

            Assert.IsTrue(loginUseCase.CanExecute);
        }
        [TestMethod]
        public void HavingAdminLoggedIn_CanExecuteIsFalse()
        {
            var mockMainDisplay = new Mock<IMainDisplay>();
            var mockAuthentification = new Mock<IAuthenticationService>();
            mockAuthentification
                .Setup(x => x.UserIsLoggedIn)
                .Returns(true);

            LoginUseCase loginUseCase = new LoginUseCase(mockAuthentification.Object, mockMainDisplay.Object);

            Assert.IsFalse(loginUseCase.CanExecute);
        }
    }
}
