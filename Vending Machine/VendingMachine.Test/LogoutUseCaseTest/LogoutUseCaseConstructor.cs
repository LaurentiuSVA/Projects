using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.UseCases;
using Moq;

namespace LogoutUseCaseTest
{
    [TestClass]
    public class LogoutUseCaseConstructor
    {
        [TestMethod]
        public void LogoutUseCase_Constructor_SetsFieldsCorrectly()
        {
            var mockAuthentification = new Mock<IAuthenticationService>();
            var logoutUseCase = new LogoutUseCase(mockAuthentification.Object);

            Assert.AreSame(mockAuthentification.Object, logoutUseCase.Authentification);
        }
    }
}
