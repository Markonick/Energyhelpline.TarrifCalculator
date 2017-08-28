using System;
using Energyhelpline.TariffCalculator.Models;

namespace Energyhelpline.TariffCalculator.Strategies
{
    public class EnergySaverCalculator : ICalculator
    {
        private readonly TariffDataModel _tariffDataModel;

        public EnergySaverCalculator(TariffDataModel tariffDataModel)
        {
            _tariffDataModel = tariffDataModel;
        }

        public decimal GetFinalCost(int gasUsage, int electricitUsage, string startingDate)
        {
            try
            {
                const int daysPerYear = 365;
                var fromDate = DateTime.ParseExact(startingDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture); ;
                var expirationDate = DateTime.ParseExact(_tariffDataModel.ExpirationDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                
                var daysBeforeExpiration = (int) (expirationDate - fromDate).TotalDays;

                var daysAfterExpiration = (daysPerYear - daysBeforeExpiration);

                var daysBeforeFraction = decimal.Divide(daysBeforeExpiration, daysPerYear);
                var daysAfterFraction = decimal.Divide(daysAfterExpiration, daysPerYear);

                var initialGasCost = daysBeforeFraction * gasUsage * _tariffDataModel.InitialGasRate;
                var initialElectricityCost = daysBeforeFraction * electricitUsage * _tariffDataModel.InitialElectricityRate;

                var finalGasCost = daysAfterFraction * gasUsage * _tariffDataModel.FinalGasRate;
                var finalElectricityCost = daysAfterFraction * electricitUsage * _tariffDataModel.FinalElectricityRate;

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