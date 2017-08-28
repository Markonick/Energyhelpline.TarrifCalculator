using Energyhelpline.TariffCalculator.Models;

namespace Energyhelpline.TariffCalculator.Strategies
{
    public interface IStrategyResolver
    {
        ICalculator GetStrategy(TariffStrategyEnum tariffStrategy, TariffData tariffData);
        TariffStrategyEnum GetEnumFromStrategy(string name);
    }
}