using System;
using Energyhelpline.TariffCalculator.Models;

namespace Energyhelpline.TariffCalculator.Strategies
{
    public class EnergySaverCalculator : ICalculator
    {
        private readonly TariffData _tariffData;

        public EnergySaverCalculator(TariffData tariffData)
        {
            _tariffData = tariffData;
        }

        public decimal GetFinalCost(int gasUsage, int electricitUsage, string startingDate)
        {
            try
            {
                const int daysPerYear = 365;
                var fromDate = DateTime.ParseExact(startingDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture); ;
                var expirationDate = DateTime.ParseExact(_tariffData.ExpirationDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                
                var daysBeforeExpiration = (int) (expirationDate - fromDate).TotalDays;

                var daysAfterExpiration = (daysPerYear - daysBeforeExpiration);

                var daysBeforeFraction = decimal.Divide(daysBeforeExpiration, daysPerYear);
                var daysAfterFraction = decimal.Divide(daysAfterExpiration, daysPerYear);

                var initialGasCost = daysBeforeFraction * gasUsage * _tariffData.InitialGasRate;
                var initialElectricityCost = daysBeforeFraction * electricitUsage * _tariffData.InitialElectricityRate;

                var finalGasCost = daysAfterFraction * gasUsage * _tariffData.FinalGasRate;
                var finalElectricityCost = daysAfterFraction * electricitUsage * _tariffData.FinalElectricityRate;

                var total = Math.Round(initialGasCost + finalGasCost.Value + initialElectricityCost + finalElectricityCost.Value, 2);

                return total;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return 0;
            }

        }
    }
}