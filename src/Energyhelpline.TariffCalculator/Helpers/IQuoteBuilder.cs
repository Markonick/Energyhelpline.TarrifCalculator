using Energyhelpline.TariffCalculator.Models;

namespace Energyhelpline.TariffCalculator.Helpers
{
    public interface IQuoteBuilder
    {
        QuoteData Build();
    }
}