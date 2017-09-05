using System;
using Energyhelpline.TariffCalculator.Models;

namespace Energyhelpline.TariffCalculator.Strategies
{
    public class StandardCalculator : AbstractCalculator
    {
        private readonly InputModel _inputModel;
        private readonly TariffDataModel _tariffDataModel;

        public StandardCalculator(InputModel inputModel, TariffDataModel tariffDataModel)
            : base(inputModel, tariffDataModel)
        {
            _inputModel = inputModel;
            _tariffDataModel = tariffDataModel;
        }

        public override decimal GetTotalAnnualCost()
        {
            var annualGas = GetAnnualCost(_inputModel.GasUsage, _tariffDataModel.InitialGasRate);
            var annualElectricity = GetAnnualCost(_inputModel.ElectricityUsage, _tariffDataModel.InitialElectricityRate);

            return Math.Round(annualGas + annualElectricity, 2);
        }

        private static decimal GetAnnualCost(int usage, decimal rate)
        {
            return usage * rate;
        }
    }
}