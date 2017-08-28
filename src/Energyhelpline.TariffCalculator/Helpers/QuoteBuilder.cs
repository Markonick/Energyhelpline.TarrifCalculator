using System;
using Energyhelpline.TariffCalculator.Models;

namespace Energyhelpline.TariffCalculator.Helpers
{
    public static class QuoteBuilder
    {
        public static QuoteData Build(int gasUsage, int electricityUsage, string cheapestTariff, decimal annualCost)
        {
            return new QuoteData
            {
                DateTimeIssued = DateTime.Now,
                GasUsage = gasUsage,
                ElectricityUsage = electricityUsage,
                CheapestTariff = cheapestTariff,
                AnnualCost = annualCost
            };
        }
    }
}