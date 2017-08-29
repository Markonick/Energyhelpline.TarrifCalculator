using System;
using Energyhelpline.TariffCalculator.Models;

namespace Energyhelpline.TariffCalculator.Tests.Builders
{
    public static class QuoteBuilder
    {
        public static QuoteDataModel Build(int gasUsage, int electricityUsage, string cheapestTariff, decimal annualCost)
        {
            return new QuoteDataModel
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