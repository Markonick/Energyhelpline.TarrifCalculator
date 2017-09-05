using System;
using Energyhelpline.TariffCalculator.Models;

namespace Energyhelpline.TariffCalculator.Strategies
{
    public abstract class AbstractCalculator : ICalculator
    {
        private readonly InputModel _inputModel;
        private readonly TariffDataModel _tariffDataModel;
        private const int DaysPerYear = 365;

        public TariffStrategyEnum Name { get; set; }

        protected AbstractCalculator(InputModel inputModel, TariffDataModel tariffDataModel)
        {
            _inputModel = inputModel;
            _tariffDataModel = tariffDataModel;
        }

        public virtual decimal GetTotalAnnualCost()
        {
            var annualGas = GetAnnualCost(_inputModel.GasUsage, _tariffDataModel.InitialGasRate, _tariffDataModel.FinalGasRate);
            var annualElectricity = GetAnnualCost(_inputModel.ElectricityUsage, _tariffDataModel.InitialElectricityRate, _tariffDataModel.FinalElectricityRate);

            return Math.Round(annualGas + annualElectricity, 2);
        }

        private decimal GetAnnualCost(int usage, decimal initialRate, decimal? finalRate)
        {
            var daysBeforeExpirationDate = (int)(_tariffDataModel.ExpirationDate - _inputModel.StartingDate).TotalDays;
            var daysAfterExpirationDate = DaysPerYear - daysBeforeExpirationDate;
            var normalisedDaysBeforeExpiration = decimal.Divide(daysBeforeExpirationDate, DaysPerYear);
            var normalisedDaysAfterExpiration = decimal.Divide(daysAfterExpirationDate, DaysPerYear);

            var initialCost = normalisedDaysBeforeExpiration * usage * initialRate;
            var finalCost = normalisedDaysAfterExpiration * usage * finalRate;
            
            return initialCost + finalCost.GetValueOrDefault();
        }
    }
}