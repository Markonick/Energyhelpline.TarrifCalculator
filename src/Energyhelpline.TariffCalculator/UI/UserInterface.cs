using System;
using System.Text;
using Energyhelpline.TariffCalculator.Helpers;
using Energyhelpline.TariffCalculator.Models;
using Energyhelpline.TariffCalculator.Services;
using Energyhelpline.TariffCalculator.Validation;

namespace Energyhelpline.TariffCalculator.UI
{
    public class UserInterface : IUserInterface
    {
        private readonly IQuoteService _quoteService;
        private readonly IEmailSender _emailSender;
        private readonly IInputValidator _inputValidator;

        public string Output { get; set; }

        public UserInterface(IQuoteService quoteService, IEmailSender emailSender, IInputValidator inputValidator)
        {
            _quoteService = quoteService;
            _emailSender = emailSender;
            _inputValidator = inputValidator;
        }

        public void PopulateQuote(int gasUsage, int electricityUsage, string startingDate)
        {
            var quoteData = _quoteService.GetBestQuote(gasUsage, electricityUsage, startingDate);

            var quoteMessage = new StringBuilder();

            quoteMessage.AppendLine("Date: " + quoteData.DateTimeIssued);
            quoteMessage.AppendLine("Gas usage: " + quoteData.GasUsage + " kWh");
            quoteMessage.AppendLine("Electricity usage: " + quoteData.ElectricityUsage + " kWh");
            quoteMessage.AppendLine("Cheapest tariff: " + quoteData.CheapestTariff);
            quoteMessage.AppendLine("Annual cost: £" + quoteData.AnnualCost);

            Output = quoteMessage.ToString();
        }
        
        public void EmailQuote()
        {
            _emailSender.SendEmail(Output);

            Console.WriteLine(Output);
            Console.ReadLine();
        }

        public void ValidateInput(InputModel input)
        {
            _inputValidator.GetResult(input);
        }
    }
}