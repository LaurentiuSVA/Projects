using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.UseCases;
using Moq;

namespace TurnOffUseCaseTest
{
    [TestClass]
    public class TurnOffCaseConstructorTest
    {
        [TestMethod]
        public void TurnOffUseCase_Constructor_SetsFieldsCorrectly()
        {
            var mockTurnoff = new Mock<ITurnOffService>();
            var mockAuthentification = new Mock<IAuthenticationService>();
            TurnOffUseCase turnOffUseCase = new TurnOffUseCase(mockTurnoff.Object, mockAuthentification.Object);

            Assert.AreSame(mockTurnoff.Object,turnOffUseCase.TurnOff);
            Assert.AreSame(mockAuthentification.Object,turnOffUseCase.AuthentificationService);
        }
    }
}
