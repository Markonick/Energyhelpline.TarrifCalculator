using System;

namespace Energyhelpline.TariffCalculator
{
    public class Calculator : ICalculator
    {
        public decimal GetFinalCost(int gasUsage, int electricitUsage, decimal initialGasRate, decimal finalGasRate, decimal initialElectricityRate, decimal finalElectricityRate, DateTime expirationDate)
        {
            const int daysPerYear = 365;

            var daysBeforeExpiration = (int)(expirationDate - DateTime.Today).TotalDays + 24;
            var daysAfterExpiration = 365 - daysBeforeExpiration;

            var initialGasCost = decimal.Divide(daysBeforeExpiration, daysPerYear) * gasUsage * initialGasRate;
            var initialElectricityCost = decimal.Divide(daysBeforeExpiration, daysPerYear) * electricitUsage * initialElectricityRate;

            var finalGasCost = decimal.Divide(daysAfterExpiration, daysPerYear) * gasUsage * finalGasRate;
            var finalElectricityCost = decimal.Divide(daysAfterExpiration, daysPerYear) * electricitUsage * finalElectricityRate;

            return Math.Round(initialGasCost + finalGasCost + initialElectricityCost + finalElectricityCost, 2);
        }
    }
}