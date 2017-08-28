using System;
using Energyhelpline.TariffCalculator.Models;

namespace Energyhelpline.TariffCalculator.Strategies
{
    public class StrategyResolver : IStrategyResolver
    {
        public StrategyResolver()
        {
        }

        public ICalculator GetStrategy(TariffStrategyEnum tariffStrategy, TariffData tariffData)
        {
            switch (tariffStrategy)
            {
                case TariffStrategyEnum.EnergySaver:
                case TariffStrategyEnum.DiscountEnergy:
                case TariffStrategyEnum.SaveOnline:
                    return new EnergySaverCalculator(tariffData);
                case TariffStrategyEnum.Standard:
                    return new StandardCalculator(tariffData);
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