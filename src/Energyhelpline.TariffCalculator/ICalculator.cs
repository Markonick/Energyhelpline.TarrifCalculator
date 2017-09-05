namespace Energyhelpline.TariffCalculator
{
    public interface ICalculator
    {
        TariffStrategyEnum Name { get; set; }
        decimal GetTotalAnnualCost();
    }
}