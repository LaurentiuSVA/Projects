using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.UseCases;
using Moq;

namespace TurnOffUseCaseTest
{
    [TestClass]
    public class TurnOffUseCaseExecuteTest
    {
        [TestMethod]
        public void HavingALogoutUseCaseInstance_WhenExecuted_UserIsLoggedOut()
        {
            var mockTurnoff = new Mock<ITurnOffService>();
            var mockAuthentification = new Mock<IAuthenticationService>();
            mockTurnoff.Setup(x => x.TurnOff());
            TurnOffUseCase turnOffUseCase = new TurnOffUseCase(mockTurnoff.Object, mockAuthentification.Object);

            turnOffUseCase.Execute();

            mockTurnoff.Verify(x => x.TurnOff(), Times.Once);
        }
    }
}
