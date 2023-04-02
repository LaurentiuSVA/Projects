using Autofac;
using iQuest.VendingMachine.AutentificationService;
using iQuest.VendingMachine.Data;
using iQuest.VendingMachine.DataLayer;
using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.Payment;
using iQuest.VendingMachine.PresentationLayer;
using iQuest.VendingMachine.UseCases;
using System;
using System.Collections.Generic;
using System.Configuration;
using VendingMachine.Business.PresentationLayer;

namespace iQuest.VendingMachine
{
    public class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                IContainer container = BuildApplication();
                using (var scope = container.BeginLifetimeScope())
                {
                    var vendingMachineApplication = scope.Resolve<VendingMachineApplication>();
                    vendingMachineApplication.Run();
                }
            }
            catch (Exception ex)
            {
                DisplayError(ex);
                Pause();
            }
        }

        private static IContainer BuildApplication()
        {
            var builder = new ContainerBuilder();
            var repositoryType = ConfigurationManager.AppSettings["repositoryType"];
            if (repositoryType == "SQL")
            {
                string connectionString = ConfigurationManager.ConnectionStrings["VendingMachineConnectionString"].ConnectionString;
                builder.RegisterType<SqlProductRepository>().As<IProductReposotory>().WithParameter("connectionString", connectionString);
            }
            else
            {
                builder.RegisterType<InMemoryProductRepository>().As<IProductReposotory>();
            }

            builder.RegisterType<VendingMachineApplication>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<MainDisplay>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<TurnOffService>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<List<IUseCase>>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<ShelfView>().As<IShelfView>().InstancePerDependency();
            builder.RegisterType<MainDisplay>().As<IMainDisplay>().InstancePerDependency();
            builder.RegisterType<BuyView>().As<IBuyView>().InstancePerDependency();
            builder.RegisterType<StockDisplay>().As<IStockDisplay>().InstancePerDependency();
            builder.RegisterType<TurnOffService>().As<ITurnOffService>().InstancePerLifetimeScope();
            builder.RegisterType<AuthenticationService>().As<IAuthenticationService>().InstancePerLifetimeScope();
            builder.RegisterType<CardPaymentTerminal>().As<ICardPaymentTerminal>().InstancePerDependency();
            builder.RegisterType<CashPaymentTerminal>().As<ICashPaymentTerminal>().InstancePerDependency();
            builder.RegisterType<CardPayment>().As<IPaymentAlgorithm>().AsSelf();
            builder.RegisterType<CashPayment>().As<IPaymentAlgorithm>().AsSelf();
            builder.Register(x => new List<IPaymentAlgorithm>
            {
                x.Resolve<CardPayment>(),
                x.Resolve<CashPayment>()
            }).InstancePerLifetimeScope();

            builder.RegisterType<PaymentUseCase>()
                .As<IPaymentUseCase>()
                .WithParameter((pi, ctx) => pi.ParameterType == typeof(List<IPaymentAlgorithm>),
                               (pi, ctx) => ctx.Resolve<List<IPaymentAlgorithm>>());

            builder.RegisterType<BuyUseCase>().As<IUseCase>().AsImplementedInterfaces();
            builder.RegisterType<LookUseCase>().As<IUseCase>().AsImplementedInterfaces();
            builder.RegisterType<LoginUseCase>().As<IUseCase>().AsImplementedInterfaces();
            builder.RegisterType<LogoutUseCase>().As<IUseCase>().AsImplementedInterfaces();
            builder.RegisterType<TurnOffUseCase>().As<IUseCase>().AsImplementedInterfaces();
            builder.RegisterType<AddProductUseCase>().As<IUseCase>().AsImplementedInterfaces();
            builder.RegisterType<RemoveProductUseCase>().As<IUseCase>().AsImplementedInterfaces();
            builder.RegisterType<SupplyUseCase>().As<IUseCase>().AsImplementedInterfaces();

            return builder.Build();
        }

        private static void DisplayError(Exception ex)
        {
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ex);
            Console.ForegroundColor = oldColor;
        }

        private static void Pause()
        {
            Console.ReadKey(true);
        }
    }
}