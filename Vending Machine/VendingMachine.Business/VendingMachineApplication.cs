using iQuest.VendingMachine.AutentificationService;
using iQuest.VendingMachine.Exceptions;
using iQuest.VendingMachine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace iQuest.VendingMachine
{
    public class VendingMachineApplication
    {
        private readonly List<IUseCase> useCases;
        private readonly IMainDisplay mainDisplay;
        private readonly ITurnOffService turnOffService;

        public VendingMachineApplication(List<IUseCase> useCases, IMainDisplay mainDisplay , ITurnOffService turnOffService)
        {
            this.useCases = useCases ?? throw new ArgumentNullException(nameof(useCases));
            this.mainDisplay = mainDisplay ?? throw new ArgumentNullException(nameof(mainDisplay));
            this.turnOffService = turnOffService ?? throw new ArgumentNullException(nameof(turnOffService));
        }

        public void Run()
        {
            while (!turnOffService.TurnOffWasRequested)
            {
                try
                {
                    IEnumerable<IUseCase> availableUseCases = useCases
                        .Where(x => x.CanExecute);
                    IUseCase useCase = mainDisplay.ChooseCommand(availableUseCases);
                    useCase.Execute();
                }
                catch (CancelException e)
                {
                    mainDisplay.DisplayExceptionDetails(e);
                }
                catch (InsufficientStockException e)
                {
                    mainDisplay.DisplayExceptionDetails(e);
                }
                catch (InvalidColumnException e)
                {
                    mainDisplay.DisplayExceptionDetails(e);
                }
                catch (InvalidPasswordException e)
                {
                    mainDisplay.DisplayExceptionDetails(e);
                }
                catch (InvalidCardNumberException e)
                {
                    mainDisplay.DisplayExceptionDetails(e);
                }
                catch (InvalidMoneyException e)
                {
                    mainDisplay.DisplayExceptionDetails(e);
                }
                catch (Exception ex)
                {
                    Exception innerException = ex.InnerException;
                }
            }
        }
    }
}
