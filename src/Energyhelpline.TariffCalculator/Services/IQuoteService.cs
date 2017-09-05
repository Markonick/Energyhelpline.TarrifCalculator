using System;
using Energyhelpline.TariffCalculator.Models;

namespace Energyhelpline.TariffCalculator.Services
{
    public interface IQuoteService
    {
        QuoteDataModel GetBestQuote(int gasUsage, int electricityUsage, DateTime startingDate);
    }
}