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
        }

        [TestCase(0, 4000, 1896.99)]
        [TestCase(0, 0, 0.0)]
        [TestCase(2000, 4000, 2687.4)]
        [TestCase(1500, 3000, 2015.55)]
        public void EnergySaver_should_calculate_correct_tariff(decimal gasUsage, decimal electricitUsage, decimal expectedResult)
        {
            _tariffData = DataBuilder.EnergySaverCreate();
            _calculator = new Calculator(_tariffData);

            var annualCost = _calculator.GetFinalCost(gasUsage, electricitUsage);
            
            Assert.That(annualCost, Is.EqualTo(expectedResult));
        }

        [TestCase(0, 4000, 3063.01)]
        [TestCase(0, 0, 0.0)]
        [TestCase(2000, 4000, 4352.05)]
        [TestCase(1500, 3000, 3264.04)]
        public void DiscountEnergy_should_calculate_correct_tariff(decimal gasUsage, decimal electricitUsage, decimal expectedResult)
        {
            _tariffData = DataBuilder.DiscountEnergyCreate();
            _calculator = new Calculator(_tariffData);

            var annualCost = _calculator.GetFinalCost(gasUsage, electricitUsage);

            Assert.That(annualCost, Is.EqualTo(expectedResult));
        }

        [TestCase(0, 4000, 183.01)]
        [TestCase(0, 0, 0)]
        [TestCase(2000, 4000, 640.82)]
        [TestCase(1500, 3000, 480.62)]
        public void SaveOnline_should_calculate_correct_tariff(decimal gasUsage, decimal electricitUsage, decimal expectedResult)
        {
            _tariffData = DataBuilder.SaveOnline();
            _calculator = new Calculator(_tariffData);

            var annualCost = _calculator.GetFinalCost(gasUsage, electricitUsage);

            Assert.That(annualCost, Is.EqualTo(expectedResult));
        }

        [TestCase(0, 4000, 183.01)]
        [TestCase(0, 0, 0)]
        [TestCase(2000, 4000, 640.82)]
        [TestCase(1500, 3000, 480.62)]
        public void Standard_should_calculate_correct_tariff(decimal gasUsage, decimal electricitUsage, decimal expectedResult)
        {
            _tariffData = DataBuilder.SaveOnline();
            _calculator = new Calculator(_tariffData);

            var annualCost = _calculator.GetFinalCost(gasUsage, electricitUsage);

            Assert.That(annualCost, Is.EqualTo(expectedResult));
        }
    }

    public static class DataBuilder
    {
        public static TariffData EnergySaverCreate()
        {
            return new TariffData
            {
                InitialGasRate = 0.25M,
                FinalGasRate = 0.50M,
                InitialElectricityRate = 0.30M,
                FinalElectricityRate = 0.60M,
                ExpirationDate = new DateTime(2017, 9, 1)
            };
        }

        public static TariffData DiscountEnergyCreate()
        {
            return new TariffData
            {
                InitialGasRate = 0.20M,
                FinalGasRate = 0.75M,
                InitialElectricityRate = 0.20M,
                FinalElectricityRate = 0.90M,
                ExpirationDate = new DateTime(2017, 10, 10)
            };
        }

        public static TariffData SaveOnline()
        {
            return new TariffData
            {
                InitialGasRate = 0.25M,
                FinalGasRate = 0.60M,
                InitialElectricityRate = 0.10M,
                FinalElectricityRate = 1.00M,
                ExpirationDate = new DateTime(2018, 8, 23)
            };
        }

        public static TariffData Standard()
        {
            return new TariffData
            {
                InitialGasRate = 0.25M,
                FinalGasRate = null,
                InitialElectricityRate = 0.30M,
                FinalElectricityRate = null,
                ExpirationDate = null
            };
        }
    }
}
