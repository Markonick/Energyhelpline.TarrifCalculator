using Energyhelpline.TariffCalculator.Models;

namespace Energyhelpline.TariffCalculator.Tests.Builders
{
    public interface IQuoteBuilder
    {
        QuoteDataModel Build();
    }
}