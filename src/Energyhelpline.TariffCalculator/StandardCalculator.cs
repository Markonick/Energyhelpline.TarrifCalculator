using System;

namespace Energyhelpline.TariffCalculator
{
    public class StandardCalculator : ICalculator
    {
        private readonly TariffData _tariffData;

        public StandardCalculator(TariffData tariffData)
        {
            _tariffData = tariffData;
        }

        public decimal GetFinalCost(decimal gasUsage, decimal electricitUsage)
        {
            var initialGasCost = gasUsage * _tariffData.InitialGasRate;
            var initialElectricityCost = electricitUsage * _tariffData.InitialElectricityRate;
            
            var finalCost = Math.Round(initialGasCost + initialElectricityCost, 2);

            return finalCost;
        }
    }
}