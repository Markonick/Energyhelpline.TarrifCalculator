using Energyhelpline.TariffCalculator.Models;

namespace Energyhelpline.TariffCalculator.Services
{
    public interface IQuoteService
    {
        QuoteData GetBestQuote(int gasUsage, int electricityUsage, string startingDate);
    }
}