using System.Text;

namespace Energyhelpline.TariffCalculator
{
    public class UserInterface
    {
        private readonly IQuoteService _quoteService;

        public UserInterface(IQuoteService quoteService)
        {
            _quoteService = quoteService;
        }

        public string OutputQuote()
        {
            var quoteData = _quoteService.GetBestQuote();

            var quoteMessage = new StringBuilder();

            quoteMessage.AppendLine("Date: " + quoteData.DateIssued);
            quoteMessage.AppendLine("Gas usage: " + quoteData.GasUsage);
            quoteMessage.AppendLine("Electricity usage: " + quoteData.ElectricityUsage);
            quoteMessage.AppendLine("Cheapest tariff: " + quoteData.CheapestTariff);
            quoteMessage.AppendLine("Annual cost: " + quoteData.AnnualCost);

            return quoteMessage.ToString();
        }
    }
}