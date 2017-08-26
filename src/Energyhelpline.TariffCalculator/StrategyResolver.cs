using System;

namespace Energyhelpline.TariffCalculator
{
    public class StrategyResolver
    {
        private readonly TariffData _tariffData;

        public StrategyResolver(TariffData tariffData)
        {
            _tariffData = tariffData;
        }

        public ICalculator GetStrategy(TariffStrategyEnum tariffStrategy)
        {
            switch (tariffStrategy)
            {
                case TariffStrategyEnum.EnergySaver:
                case TariffStrategyEnum.DiscountEnergy:
                case TariffStrategyEnum.SaveOnline:
                    return new EnergySaverCalculator(_tariffData);
                case TariffStrategyEnum.Standard:
                    return new StandardCalculator(_tariffData);
                default:
                    throw new Exception();
            }
        }
    }
}