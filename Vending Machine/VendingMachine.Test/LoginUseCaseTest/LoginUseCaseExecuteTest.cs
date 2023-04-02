using iQuest.VendingMachine.Exceptions;
using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.UseCases;
using Moq;

namespace LoginUseCaseTest
{
    [TestClass]
    public class LoginUseCaseExecuteTest
    {

        [TestMethod]
        public void HavingAloginUseCaseInstance_WhenExecuted_VerifyIfThePasswordIntroducedFromUserIsCorrectForLogin()
        {
            var correctPassword = "1234";
            var mockMainDisplay = new Mock<IMainDisplay>();
            var mockAuthentification = new Mock<IAuthenticationService>();
            LoginUseCase loginUseCase = new LoginUseCase(mockAuthentification.Object, mockMainDisplay.Object);
            mockMainDisplay
                .Setup(x => x.AskForPassword())
                .Returns(correctPassword);
           
            loginUseCase.Execute();

            mockAuthentification.Verify(x => x.Login(correctPassword), Times.Once);
        }

        [TestMethod]
        public void HavingAloginUseCaseInstance_WhenExecuted_ExceptionWhenPasswordFromUserIsInvalid()
        {
            var wrongPassword = "wrong";
            var mockMainDisplay = new Mock<IMainDisplay>();
            var mockAuthentification = new Mock<IAuthenticationService>();
            LoginUseCase loginUseCase = new LoginUseCase(mockAuthentification.Object, mockMainDisplay.Object);
            mockMainDisplay
                .Setup(x => x.AskForPassword())
                .Returns(wrongPassword);
            mockAuthentification.Setup(x => x.Login(wrongPassword)).Throws<InvalidPasswordException>();

            Assert.ThrowsException<InvalidPasswordException>(() => loginUseCase.Execute());
        }
    }
}