namespace Energyhelpline.TariffCalculator
{
    public interface ICalculator
    {
        decimal GetFinalCost(int gasUsage, int electricitUsage, string startingDate);
    }
}