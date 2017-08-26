using System;

namespace Energyhelpline.TariffCalculator
{
    public class EnergySaverCalculator : ICalculator
    {
        private readonly TariffData _tariffData;

        public EnergySaverCalculator(TariffData tariffData)
        {
            _tariffData = tariffData;
        }

        public decimal GetFinalCost(decimal gasUsage, decimal electricitUsage)
        {
            const int daysPerYear = 365;
            
            var expirationDate = DateTime.ParseExact(_tariffData.ExpirationDate, "yyyy/M/d", System.Globalization.CultureInfo.InvariantCulture);
            var daysBeforeExpiration = (int)(expirationDate - DateTime.Today).TotalDays;
            
            var daysAfterExpiration = (daysPerYear - daysBeforeExpiration);
            
            var daysBeforeFraction = decimal.Divide(daysBeforeExpiration, daysPerYear);
            var daysAfterFraction = decimal.Divide(daysAfterExpiration, daysPerYear);

            var initialGasCost = daysBeforeFraction * gasUsage * _tariffData.InitialGasRate;
            var initialElectricityCost = daysBeforeFraction * electricitUsage * _tariffData.InitialElectricityRate;

            var finalGasCost = daysAfterFraction * gasUsage * _tariffData.FinalGasRate;
            var finalElectricityCost = daysAfterFraction * electricitUsage * _tariffData.FinalElectricityRate;

            var total =  Math.Round(initialGasCost + finalGasCost.Value + initialElectricityCost + finalElectricityCost.Value, 2);

            return total;
        }
    }
}