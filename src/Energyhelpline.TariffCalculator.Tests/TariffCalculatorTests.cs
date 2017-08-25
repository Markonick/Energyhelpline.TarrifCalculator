using System;
using NUnit.Framework;

namespace Energyhelpline.TariffCalculator.Tests
{
    [TestFixture]
    public class TariffCalculatorTests
    {
        private ICalculator _calculator;

        [SetUp]
        public void SetUp()
        {
            _calculator = new Calculator();
        }

        [TestCase(2000, 4000, 0.25, 0.5, 0.3, 0.6, "01/01/2018", 2687.4)]
        [TestCase(1500, 3000, 0.25, 0.5, 0.3, 0.6, "01/01/2018", 2015.55)]
        public void EnergySaver_should_calculate_correct_tariff(int gasUsage, int electricitUsage, decimal initialGasRate, decimal finalGasRate, decimal initialElectricityRate, decimal finalElectricityRate, DateTime expirationDate, decimal expectedResult)
        {
            var annualCost = _calculator.GetFinalCost(gasUsage, electricitUsage, initialGasRate, finalGasRate, initialElectricityRate, finalElectricityRate, expirationDate);
            
            Assert.That(annualCost, Is.EqualTo(expectedResult));
        }
    }
}
