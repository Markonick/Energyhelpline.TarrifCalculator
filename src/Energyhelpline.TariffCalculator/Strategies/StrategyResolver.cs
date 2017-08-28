using System;
using Energyhelpline.TariffCalculator.Models;

namespace Energyhelpline.TariffCalculator.Strategies
{
    public class StrategyResolver : IStrategyResolver
    {
        public StrategyResolver()
        {
        }

        public ICalculator GetStrategy(TariffStrategyEnum tariffStrategy, TariffDataModel tariffDataModel)
        {
            switch (tariffStrategy)
            {
                case TariffStrategyEnum.EnergySaver:
                case TariffStrategyEnum.DiscountEnergy:
                case TariffStrategyEnum.SaveOnline:
                    return new EnergySaverCalculator(tariffDataModel);
                case TariffStrategyEnum.Standard:
                    return new StandardCalculator(tariffDataModel);
                default:
                    throw new Exception();
            }
        }

        public TariffStrategyEnum GetEnumFromStrategy(string name)
        {
            switch (name)
            {
                case "Energy Saver":
                    return TariffStrategyEnum.EnergySaver;
                case "Discount Energy":
                    return TariffStrategyEnum.DiscountEnergy;
                case "Save Online":
                    return TariffStrategyEnum.SaveOnline;
                case "Standard":
                    return TariffStrategyEnum.Standard;
                default:
                    throw new Exception();
            }
        }
    }
}