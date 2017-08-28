using System;
using System.IO;
using Energyhelpline.TariffCalculator.Helpers;
using Energyhelpline.TariffCalculator.Models;
using Energyhelpline.TariffCalculator.Repositories;
using Energyhelpline.TariffCalculator.Services;
using Energyhelpline.TariffCalculator.Strategies;
using Energyhelpline.TariffCalculator.UI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Energyhelpline.TariffCalculator
{
    public class Bootstrapper
    {
        public static IServiceProvider ConfigureServices()
        {
            var configuration = GetConfiguration();

            IServiceCollection service = new ServiceCollection();

            var emailSettings = configuration.GetSection("emailSettings");
            var fromAddress = emailSettings.GetValue<string>("FromAddress");
            var toAddress = emailSettings.GetValue<string>("ToAddress");
            var username = emailSettings.GetValue<string>("Username");
            var password = emailSettings.GetValue<string>("Password");
            var subject = emailSettings.GetValue<string>("Subject");
            var smtpServer = emailSettings.GetValue<string>("SmtpServer");
            var port = emailSettings.GetValue<int>("Port");

            var quoteSettings = configuration.GetSection("quoteSettings");
            var gasUsage = quoteSettings.GetValue<int>("GasUsage");
            var electricityUsage = quoteSettings.GetValue<int>("ElectricityUsage");
            var startingDate = quoteSettings.GetValue<string>("StartingDate");
            var fileName = quoteSettings.GetValue<string>("FileName");

            var emailConfig = new EmailConfig
            {
                FromAddress = fromAddress,
                ToAddress = toAddress,
                Username = username,
                Password = password,
                Subject = subject,
                Message = "Best Tariff Quote",
                SmtpServer = smtpServer,
                Port = port
            };

            //service.AddSingleton<AbstractValidator<CommandViewModel>, LoanRangeValidator>(x => new LoanRangeValidator(minimumLoan, maximumLoan));

            service.AddSingleton<ICsvFileReader, CsvFileReader>(x => new CsvFileReader());
            service.AddSingleton<IRepository, CsvQuoteRepository>(x => new CsvQuoteRepository(new CsvFileReader(), fileName));
            service.AddSingleton<IStrategyResolver, StrategyResolver>(x => new StrategyResolver());
            service.AddSingleton<IQuoteService, QuoteService>(x => new QuoteService(new CsvQuoteRepository(new CsvFileReader(), fileName), new StrategyResolver()));
            service.AddSingleton<IUserInterface, UserInterface>(x => new UserInterface(new QuoteService(new CsvQuoteRepository(new CsvFileReader(), fileName), new StrategyResolver()), new EmailSender(emailConfig), gasUsage, electricityUsage, startingDate));

            service.AddSingleton<IEmailSender, EmailSender>(x => new EmailSender(emailConfig));

            var provider = service.BuildServiceProvider();

            return provider;
        }

        public static IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            /*if (env.IsDevelopment())
            {
                builder.AddUserSecrets();
            }*/

            return builder.Build();
        }
    }
}