using System;
using Energyhelpline.TariffCalculator.Strategies;
using Xunit;

namespace Energyhelpline.TariffCalculator.Tests
{
    public class CalculatorTests
    {
        [Theory]
        [InlineData(0, 0, 1.0, 1.0, 0.25, 0.70, "02/09/2017", "01/01/2018", 1.10)]
        [InlineData(0, 1, 0.25, 0.70, 0.25, 0.70, "02/09/2017", "01/01/2018", 1.10)]
        [InlineData(1, 1, 0.25, 0.70, 0.25, 0.70, "02/09/2017", "01/01/2018", 1.10)]
        [InlineData(1500, 3000, 0.25, 0.50, 0.30, 0.60, "01/08/2017", "01/01/2018", 2015.55)]
        [InlineData(2000, 4000, 0.25, 0.50, 0.30, 0.60, "01/08/2017", "01/01/2018", 2015.55)]
        public void EnergySaverCalculator_should_output_correct_tariff(int gas, int electricity, decimal initGasRate, decimal finalGasRate, decimal initElecRate, decimal finalElecRate, DateTime startingDate, DateTime expirationDate, decimal expected)
        {
            var energySaver = new EnergySaverCalculator(gas, electricity, initGasRate, finalGasRate, initElecRate, finalElecRate, startingDate, expirationDate);
            var annualCost = energySaver.GetTotalAnnualCost();

            Assert.Equal(annualCost, expected);
        }

        [Theory]
        [InlineData(0, 0, 0.25, 0.70, 0.25, 0.70, "02/09/2017", "01/01/2018", 1.10)]
        [InlineData(0, 1, 0.25, 0.70, 0.25, 0.70, "02/09/2017", "01/01/2018", 1.10)]
        [InlineData(1, 1, 0.25, 0.70, 0.25, 0.70, "02/09/2017", "01/01/2018", 1.10)]
        [InlineData(1500, 3000, 0.20, 0.75, 0.20, 0.90, "01/08/2017", "01/01/2018", 2015.55)]
        [InlineData(2000, 4000, 0.20, 0.75, 0.20, 0.90, "01/08/2017", "01/01/2018", 2015.55)]
        public void DiscountEnergyCalculator_should_output_correct_tariff(int gas, int electricity, decimal initGasRate, decimal finalGasRate, decimal initElecRate, decimal finalElecRate, DateTime startingDate, DateTime expirationDate, decimal expected)
        {
            var energySaver = new EnergySaverCalculator(gas, electricity, initGasRate, finalGasRate, initElecRate, finalElecRate, startingDate, expirationDate);
            var annualCost = energySaver.GetTotalAnnualCost();

            Assert.Equal(annualCost, expected);
        }

        [Theory]
        [InlineData(0, 0, 1.0, 1.0, 2.00)]
        [InlineData(0, 1, 1.0, 1.0, 2.00)]
        [InlineData(1, 1, 1.0, 1.0, 2.00)]
        [InlineData(1500, 2000, 0.65, 0.80, 12000.00)]
        [InlineData(2000, 4000, 0.65, 0.80, 12000.00)]
        public void StandardCalculator_should_output_correct_tariff(int gas, int elec, decimal gasRate, decimal elecRate, decimal expected)
        {
            var standard = new StandardCalculator(gas, elec, gasRate, elecRate);
            var annualCost = standard.GetTotalAnnualCost();

            Assert.Equal(annualCost, expected);
        }

        [Theory]
        [InlineData(0, 0, 0.25, 0.70, 0.25, 0.70, "02/09/2017", "01/01/2018", 1.10)]
        [InlineData(0, 1, 0.25, 0.70, 0.25, 0.70, "02/09/2017", "01/01/2018", 1.10)]
        [InlineData(1, 1, 0.25, 0.70, 0.25, 0.70, "02/09/2017", "01/01/2018", 1.10)]
        [InlineData(1500, 3000, 0.25, 0.60, 0.10, 1.00, "01/08/2017", "23/08/2017", 2015.55)]
        [InlineData(2000, 4000, 0.25, 0.60, 0.10, 1.00, "01/08/2017", "23/08/2017", 2015.55)]
        public void SaveOnlineCalculator_should_output_correct_tariff(int gas, int electricity, decimal initGasRate, decimal finalGasRate, decimal initElecRate, decimal finalElecRate, DateTime startingDate, DateTime expirationDate, decimal expected)
        {
            var energySaver = new EnergySaverCalculator(gas, electricity, initGasRate, finalGasRate, initElecRate, finalElecRate, startingDate, expirationDate);
            var annualCost = energySaver.GetTotalAnnualCost();

            Assert.Equal(annualCost, expected);
        }

        [Theory]
        [InlineData(0, 0, 0.25, 0.70, 0.25, 0.70, "02/09/2018", "01/01/2018", 1.10)]
        [InlineData(0, 1, 0.25, 0.70, 0.25, 0.70, "02/09/2018", "01/01/2018", 1.10)]
        [InlineData(1, 1, 0.25, 0.70, 0.25, 0.70, "02/09/2018", "01/01/2018", 1.10)]
        [InlineData(1500, 3000, 0.25, 0.50, 0.30, 0.60, "02/08/2018", "01/01/2018", 2015.55)]
        public void EnergySaverCalculator_should_throw_exception_when_starting_date_after_expiration_date(int gas, int electricity, decimal initGasRate, decimal finalGasRate, decimal initElecRate, decimal finalElecRate, DateTime startingDate, DateTime expirationDate, decimal expected)
        {
            var energySaver = new EnergySaverCalculator(gas, electricity, initGasRate, finalGasRate, initElecRate, finalElecRate, startingDate, expirationDate);
            var annualCost = energySaver.GetTotalAnnualCost();

            Assert.Equal(annualCost, expected);
        }

    }
}
