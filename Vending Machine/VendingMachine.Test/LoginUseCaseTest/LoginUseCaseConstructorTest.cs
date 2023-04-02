using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.UseCases;
using Moq;

namespace LoginUseCaseTest
{
    [TestClass]
    public class LoginUseCaseConstructorTest
    {
        [TestMethod] 
        public void LoginUseCase_Constructor_SetsFieldsCorrectly()
        {
            var mockAuthentification = new Mock<IAuthenticationService>();
            var mockMainDisplay = new Mock<IMainDisplay>();
            var loginUseCase = new LoginUseCase(mockAuthentification.Object, mockMainDisplay.Object);

            Assert.AreSame(mockAuthentification.Object, loginUseCase.Authentification);
            Assert.AreSame(mockMainDisplay.Object, loginUseCase.MainDisplay);
        }
    }
}
