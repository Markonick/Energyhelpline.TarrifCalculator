using System;
using System.Text;
using System.Threading.Tasks;
using Energyhelpline.TariffCalculator.Helpers;
using Energyhelpline.TariffCalculator.Models;
using Energyhelpline.TariffCalculator.Services;
using Energyhelpline.TariffCalculator.Validation;

namespace Energyhelpline.TariffCalculator.UI
{
    public class AppController : IAppController
    {
        private readonly IQuoteService _quoteService;
        private readonly IEmailService _emailService;
        
        public AppController(IQuoteService quoteService, IEmailService emailService)
        {
            _quoteService = quoteService;
            _emailService = emailService;
        }

        public async void Run()
        {
            var quoteData = _quoteService.GetBestQuote(gasUsage, electricityUsage, startingDate);

            var quoteMessage = new StringBuilder();

            quoteMessage.AppendLine("Date: " + quoteData.DateTimeIssued);
            quoteMessage.AppendLine("Gas usage: " + quoteData.GasUsage + " kWh");
            quoteMessage.AppendLine("Electricity usage: " + quoteData.ElectricityUsage + " kWh");
            quoteMessage.AppendLine("Cheapest tariff: " + quoteData.CheapestTariff);
            quoteMessage.AppendLine("Annual cost: £" + quoteData.AnnualCost);
       
            await _emailService.SendEmail(quoteMessage.ToString());

            Console.WriteLine(quoteMessage);
            Console.ReadLine();
        }
    }
}