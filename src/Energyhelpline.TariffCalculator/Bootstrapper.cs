using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Energyhelpline.TariffCalculator.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Energyhelpline.TariffCalculator
{
    public class Bootstrapper
    {
        public static IServiceProvider ConfigureServices(string path)
        {
            var configuration = GetConfiguration(path);

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

            //service.AddSingleton<AbstractValidator<CommandViewModel>, LoanRangeValidator>(x => new LoanRangeValidator(minimumLoan, maximumLoan));
            //service.AddSingleton<IQuoteBuilder, QuoteBuilder>(x => new QuoteBuilder(gasUsage, electricityUsage));
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
            service.AddSingleton<IEmailSender, EmailSender>(x => new EmailSender(emailConfig));

            var provider = service.BuildServiceProvider();

            return service.BuildServiceProvider();
        }

        public static IConfigurationRoot GetConfiguration(string path)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(path)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            return builder.Build();
        }
    }
}