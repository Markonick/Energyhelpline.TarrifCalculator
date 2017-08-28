using Energyhelpline.TariffCalculator.Models;

namespace Energyhelpline.TariffCalculator.Strategies
{
    public interface IStrategyResolver
    {
        ICalculator GetStrategy(TariffStrategyEnum tariffStrategy, TariffDataModel tariffDataModel);
        TariffStrategyEnum GetEnumFromStrategy(string name);
    }
}