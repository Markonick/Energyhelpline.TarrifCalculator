using System;
using Energyhelpline.TariffCalculator.Models;

namespace Energyhelpline.TariffCalculator.Strategies
{
    public class SaveOnlineCalculator : AbstractCalculator
    {
        public SaveOnlineCalculator(InputModel inputModel, TariffDataModel tariffDataModel) 
            : base(inputModel, tariffDataModel)
        {
        }
    }
}
