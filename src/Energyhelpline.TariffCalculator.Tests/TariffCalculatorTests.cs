using System;
using Energyhelpline.TariffCalculator.Models;
using Energyhelpline.TariffCalculator.Strategies;
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

        [TestCase(0, 4000, 2380.27)]
        [TestCase(0, 0, 0.0)]
        [TestCase(2000, 4000, 3372.05)]
        [TestCase(1500, 3000, 2529.04)]
        public void EnergySaver_should_calculate_correct_tariff(decimal gasUsage, decimal electricitUsage, decimal expectedResult)
        {
            _tariffData = DataBuilder.EnergySaverCreate();
            _calculator = new EnergySaverCalculator(_tariffData);

            var annualCost = _calculator.GetFinalCost(gasUsage, electricitUsage);
            
            Assert.That(annualCost, Is.EqualTo(expectedResult));
        }

        [TestCase(0, 4000, 3254.79)]
        [TestCase(0, 0, 0.0)]
        [TestCase(2000, 4000, 4619.18)]
        [TestCase(1500, 3000, 3464.38)]
        public void DiscountEnergy_should_calculate_correct_tariff(decimal gasUsage, decimal electricitUsage, decimal expectedResult)
        {
            _tariffData = DataBuilder.DiscountEnergyCreate();
            _calculator = new EnergySaverCalculator(_tariffData);

            var annualCost = _calculator.GetFinalCost(gasUsage, electricitUsage);

            Assert.That(annualCost, Is.EqualTo(expectedResult));
        }

        [TestCase(0, 4000, 429.59)]
        [TestCase(0, 0, 0)]
        [TestCase(2000, 4000, 935.34)]
        [TestCase(1500, 3000, 701.51)]
        public void SaveOnline_should_calculate_correct_tariff(decimal gasUsage, decimal electricitUsage, decimal expectedResult)
        {
            _tariffData = DataBuilder.SaveOnline();
            _calculator = new EnergySaverCalculator(_tariffData);

            var annualCost = _calculator.GetFinalCost(gasUsage, electricitUsage);

            Assert.That(annualCost, Is.EqualTo(expectedResult));
        }

        [TestCase(0, 4000, 400)]
        [TestCase(0, 0, 0)]
        [TestCase(2000, 4000, 900)]
        [TestCase(1500, 3000, 675)]
        public void Standard_should_calculate_correct_tariff(decimal gasUsage, decimal electricitUsage, decimal expectedResult)
        {
            _tariffData = DataBuilder.SaveOnline();
            _calculator = new StandardCalculator(_tariffData);

            var annualCost = _calculator.GetFinalCost(gasUsage, electricitUsage);

            Assert.That(annualCost, Is.EqualTo(expectedResult));
        }
    }
}
