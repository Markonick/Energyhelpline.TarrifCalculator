using System;
using System.Text;
using Energyhelpline.TariffCalculator.Helpers;
using Energyhelpline.TariffCalculator.Services;

namespace Energyhelpline.TariffCalculator.UI
{
    public class UserInterface : IUserInterface
    {
        private readonly IQuoteService _quoteService;
        private readonly IEmailSender _emailSender;
        private readonly int _gasUsage;
        private readonly int _electricityUsage;
        private readonly string _startingDate;

        public string Output { get; set; }

        public UserInterface(IQuoteService quoteService, IEmailSender emailSender, int gasUsage, int electricityUsage, string startingDate)
        {
            _quoteService = quoteService;
            _emailSender = emailSender;
            _gasUsage = gasUsage;
            _electricityUsage = electricityUsage;
            _startingDate = startingDate;
        }

        public void PopulateQuote()
        {
            var quoteData = _quoteService.GetBestQuote(_gasUsage, _electricityUsage, _startingDate);

            var quoteMessage = new StringBuilder();

            quoteMessage.AppendLine("Date: " + quoteData.DateTimeIssued);
            quoteMessage.AppendLine("Gas usage: " + quoteData.GasUsage);
            quoteMessage.AppendLine("Electricity usage: " + quoteData.ElectricityUsage);
            quoteMessage.AppendLine("Cheapest tariff: " + quoteData.CheapestTariff);
            quoteMessage.AppendLine("Annual cost: " + quoteData.AnnualCost);

            Output = quoteMessage.ToString();
        }
        
        public void EmailQuote()
        {
            Console.WriteLine(Output);
            Console.ReadLine();
            _emailSender.SendEmail();
        }
    }
}