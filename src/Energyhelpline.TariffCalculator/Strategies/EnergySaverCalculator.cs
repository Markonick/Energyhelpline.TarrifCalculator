﻿using System;
using Energyhelpline.TariffCalculator.Models;

namespace Energyhelpline.TariffCalculator.Strategies
{
    public class EnergySaverCalculator : AbstractCalculator
    {
        public EnergySaverCalculator(InputModel inputModel, TariffDataModel tariffDataModel) 
            : base(inputModel, tariffDataModel)
        {
        }
    }
}
