using System;
using NUnit.Framework;

namespace Energyhelpline.TariffCalculator.Tests
{
    [TestFixture]
    public class TariffCalculatorTests
    {
        private ICalculator _calculator;
        private TariffData _tariffData;

        [SetUp]
        public void SetUp()
        {
            _tariffData = DataBuilder.Create();
            _calculator = new Calculator(_tariffData);
        }

        [TestCase(2000, 4000, 2687.4)]
        [TestCase(1500, 3000, 2015.55)]
        public void EnergySaver_should_calculate_correct_tariff(decimal gasUsage, decimal electricitUsage, decimal expectedResult)
        {
            var annualCost = _calculator.GetFinalCost(gasUsage, electricitUsage);
            
            Assert.That(annualCost, Is.EqualTo(expectedResult));
        }
    }

    public static class DataBuilder
    {
        public static TariffData Create()
        {
            return new TariffData
            {
                InitialGasRate = 0.25M,
                FinalGasRate = 0.50M,
                InitialElectricityRate = 0.30M,
                FinalElectricityRate = 0.60M,
                ExpirationDate = new DateTime(2018, 1, 1)
            };
        }
    }
}
