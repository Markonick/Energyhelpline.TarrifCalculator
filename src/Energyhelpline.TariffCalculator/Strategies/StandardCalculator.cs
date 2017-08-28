using System;
using Energyhelpline.TariffCalculator.Models;

namespace Energyhelpline.TariffCalculator.Strategies
{
    public class StandardCalculator : ICalculator
    {
        private readonly TariffData _tariffData;

        public StandardCalculator(TariffData tariffData)
        {
            _tariffData = tariffData;
        }

        public decimal GetFinalCost(int gasUsage, int electricitUsage, string startingDate)
        {
            var initialGasCost = gasUsage * _tariffData.InitialGasRate;
            var initialElectricityCost = electricitUsage * _tariffData.InitialElectricityRate;
            
            var finalCost = Math.Round(initialGasCost + initialElectricityCost, 2);

            return finalCost;
        }
    }
}