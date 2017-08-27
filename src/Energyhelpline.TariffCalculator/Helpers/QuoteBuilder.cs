using System;

namespace Energyhelpline.TariffCalculator.Helpers
{
    public class QuoteBuilder : IQuoteBuilder
    {
        private readonly int _gasUsage;
        private readonly int _electricityUsage;
        private readonly string _cheapestTariff;
        private readonly decimal _annualCost;

        public QuoteBuilder(int gasUsage, int electricityUsage, string cheapestTariff, decimal annualCost )
        {
            _gasUsage = gasUsage;
            _electricityUsage = electricityUsage;
            _cheapestTariff = cheapestTariff;
            _annualCost = annualCost;
        }

        public QuoteData Build()
        {
            return new QuoteData
            {
                DateIssued = DateTime.Now.ToString("yyyy/M/d"),
                GasUsage = _gasUsage,
                ElectricityUsage = _electricityUsage,
                CheapestTariff = _cheapestTariff,
                AnnualCost = _annualCost
            };
        }
    }
}