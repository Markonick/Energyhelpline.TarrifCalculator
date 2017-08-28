using System;
using Energyhelpline.TariffCalculator.Models;

namespace Energyhelpline.TariffCalculator.Strategies
{
    public class StandardCalculator : ICalculator
    {
        private readonly TariffDataModel _tariffDataModel;

        public StandardCalculator(TariffDataModel tariffDataModel)
        {
            _tariffDataModel = tariffDataModel;
        }

        public decimal GetFinalCost(int gasUsage, int electricitUsage, string startingDate)
        {
            var initialGasCost = gasUsage * _tariffDataModel.InitialGasRate;
            var initialElectricityCost = electricitUsage * _tariffDataModel.InitialElectricityRate;
            
            var finalCost = Math.Round(initialGasCost + initialElectricityCost, 2);

            return finalCost;
        }
    }
}