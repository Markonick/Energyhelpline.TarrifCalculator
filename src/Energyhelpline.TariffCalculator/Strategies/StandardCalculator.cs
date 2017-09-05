using System;

namespace Energyhelpline.TariffCalculator.Strategies
{
    public class StandardCalculator : ICalculator
    {
        private readonly int _gasUsage;
        private readonly int _electricityUsage;
        private readonly decimal _gasRate;
        private readonly decimal _electricityRate;

        public StandardCalculator(int gasUsage, int electricityUsage, decimal gasRate, decimal electricityRate)
        {
            _gasUsage = gasUsage;
            _electricityUsage = electricityUsage;
            _gasRate = gasRate;
            _electricityRate = electricityRate;
        }

        public decimal GetTotalAnnualCost()
        {
            var annualGas = GetAnnualCost(_gasUsage, _gasRate);
            var annualElectricity = GetAnnualCost(_electricityUsage, _electricityRate);

            return Math.Round(annualGas + annualElectricity, 2);
        }

        private static decimal GetAnnualCost(int usage, decimal rate)
        {
            return usage * rate;
        }
    }
}