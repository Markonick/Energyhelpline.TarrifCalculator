using System;
using Energyhelpline.TariffCalculator.Models;

namespace Energyhelpline.TariffCalculator.Strategies
{
    public class DiscountEnergyCalculator : AbstractCalculator
    {
        public DiscountEnergyCalculator(InputModel inputModel, TariffDataModel tariffDataModel) 
            : base(inputModel, tariffDataModel)
        {
        }
    }
}
