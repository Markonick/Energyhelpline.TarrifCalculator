using System;

namespace Energyhelpline.TariffCalculator.Strategies
{
    public class EnergySaverCalculator : ICalculator
    {
        private readonly int _gasUsage;
        private readonly int _electricityUsage;
        private readonly decimal _initialGasRate;
        private readonly decimal _finalGasRate;
        private readonly decimal _initialElectricityRate;
        private readonly decimal _finalElectricityRate;
        private readonly DateTime _startingDate;
        private readonly DateTime _expirationDate;
        private const int DaysPerYear = 365;

        public EnergySaverCalculator(int gasUsage, int electricityUsage, decimal initialGasRate, decimal finalGasRate, decimal initialElectricityRate, decimal finalElectricityRate, DateTime startingDate, DateTime expirationDate)
        {
            _gasUsage = gasUsage;
            _electricityUsage = electricityUsage;
            _initialGasRate = initialGasRate;
            _finalGasRate = finalGasRate;
            _initialElectricityRate = initialElectricityRate;
            _finalElectricityRate = finalElectricityRate;
            _startingDate = startingDate;
            _expirationDate = expirationDate;
        }

        public decimal GetTotalAnnualCost()
        {
            var annualGas = GetAnnualCost(_gasUsage, _initialGasRate, _finalGasRate);
            var annualElectricity = GetAnnualCost(_electricityUsage, _initialElectricityRate, _finalElectricityRate);

            return Math.Round(annualGas + annualElectricity, 2);
        }

        private decimal GetAnnualCost(int usage, decimal initialRate, decimal finalRate)
        {
            var daysBeforeExpirationDate = (int)(_expirationDate - _startingDate).TotalDays;
            var daysAfterExpirationDate = DaysPerYear - daysBeforeExpirationDate;
            var normalisedDaysBeforeExpiration = decimal.Divide(daysBeforeExpirationDate, DaysPerYear);
            var normalisedDaysAfterExpiration = decimal.Divide(daysAfterExpirationDate, DaysPerYear);

            var initialCost = normalisedDaysBeforeExpiration * usage * initialRate;
            var finalCost = normalisedDaysAfterExpiration * usage * finalRate;

            return initialCost + finalCost;
        }
    }
}