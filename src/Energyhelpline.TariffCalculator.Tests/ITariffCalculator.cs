using NUnit.Framework.Constraints;

namespace Energyhelpline.TariffCalculator.Tests
{
    public interface ITariffCalculator
    {
        decimal GetFinalCost();
    }
}