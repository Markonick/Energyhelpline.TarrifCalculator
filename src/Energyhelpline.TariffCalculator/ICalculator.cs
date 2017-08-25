using System;

namespace Energyhelpline.TariffCalculator
{
    public interface ICalculator
    {
        decimal GetFinalCost(int gasUsage, int electricitUsage, decimal initialGasRate, decimal finalGasRate, decimal initialElectricityRate, decimal finalElectricityRate, DateTime expirationDate);
    }
}