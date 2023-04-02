using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.UseCases;
using Moq;

namespace TurnOffUseCaseTest
{
    [TestClass]
    public class TurnOffUseCaseCanExecuteTest
    {
        [TestMethod]
        public void HavingNoAdminLoggedIn_CanExecuteIsFalse()
        {
            var mockTurnOff = new Mock<ITurnOffService>();
            var mockAuthentification = new Mock<IAuthenticationService>();
            mockAuthentification
                .Setup(x => x.UserIsLoggedIn)
                .Returns(false);
            TurnOffUseCase turnOffUse= new TurnOffUseCase(mockTurnOff.Object,mockAuthentification.Object);

            turnOffUse.Execute();

            Assert.IsFalse(turnOffUse.CanExecute);
        }
        [TestMethod]
        public void HavingAdminLoggedIn_CanExecuteIsTrue()
        {
            var mockTurnOff = new Mock<ITurnOffService>();
            var mockAuthentification = new Mock<IAuthenticationService>();
            mockAuthentification
                .Setup(x => x.UserIsLoggedIn)
                .Returns(true);
            TurnOffUseCase turnOffUse = new TurnOffUseCase(mockTurnOff.Object, mockAuthentification.Object);

            turnOffUse.Execute();

            Assert.IsTrue(turnOffUse.CanExecute);
        }
    }
}
