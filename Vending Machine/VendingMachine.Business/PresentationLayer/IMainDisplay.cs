using System;
using System.Collections.Generic;

namespace iQuest.VendingMachine.Interfaces
{
    public interface IMainDisplay
    {
        public IUseCase ChooseCommand(IEnumerable<IUseCase> useCases);

        private static void DisplayUseCase(IUseCase useCase) { }

        public string ReadCommandName();

        public string AskForPassword();

        public void DisplayExceptionDetails(Exception exception);
    }
}
