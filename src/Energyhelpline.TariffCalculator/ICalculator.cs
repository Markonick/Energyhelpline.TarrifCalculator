namespace Energyhelpline.TariffCalculator
{
    public interface ICalculator
    {
        decimal GetFinalCost(decimal gasUsage, decimal electricitUsage);
    }
}