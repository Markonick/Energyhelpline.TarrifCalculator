using System;

namespace Energyhelpline.TariffCalculator
{
    public class Calculator : ICalculator
    {
        private readonly TariffData _tariffData;

        public Calculator(TariffData tariffData)
        {
            _tariffData = tariffData;
        }

        public decimal GetFinalCost(decimal gasUsage, decimal electricitUsage)
        {
            const int daysPerYear = 365;

            var expirationDate = _tariffData.ExpirationDate;

            if (expirationDate != null)
            {
                var daysBeforeExpiration = (int)(expirationDate - DateTime.Today).TotalDays;
                var daysAfterExpiration = 365 - daysBeforeExpiration;
            }

            var initialGasCost = decimal.Divide(daysBeforeExpiration, daysPerYear) * gasUsage * _tariffData.InitialGasRate;
            var initialElectricityCost = decimal.Divide(daysBeforeExpiration, daysPerYear) * electricitUsage * _tariffData.InitialElectricityRate;

            var finalGasCost = decimal.Divide(daysAfterExpiration, daysPerYear) * gasUsage * _tariffData.FinalGasRate;
            var finalElectricityCost = decimal.Divide(daysAfterExpiration, daysPerYear) * electricitUsage * _tariffData.FinalElectricityRate;

            return Math.Round(initialGasCost + finalGasCost + initialElectricityCost + finalElectricityCost, 2);
        }
    }
}