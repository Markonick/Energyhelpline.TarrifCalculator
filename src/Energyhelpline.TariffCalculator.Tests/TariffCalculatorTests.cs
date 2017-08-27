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

        [TestCase(0, 4000, 2383.56)]
        [TestCase(0, 0, 0.0)]
        [TestCase(2000, 4000, 3376.71)]
        [TestCase(1500, 3000, 2532.53)]
        public void EnergySaver_should_calculate_correct_tariff(decimal gasUsage, decimal electricitUsage, decimal expectedResult)
        {
            _tariffData = DataBuilder.EnergySaverCreate();
            _calculator = new EnergySaverCalculator(_tariffData);

            var annualCost = _calculator.GetFinalCost(gasUsage, electricitUsage);
            
            Assert.That(annualCost, Is.EqualTo(expectedResult));
        }

        [TestCase(0, 4000, 3262.47)]
        [TestCase(0, 0, 0.0)]
        [TestCase(2000, 4000, 4629.86)]
        [TestCase(1500, 3000, 3472.4)]
        public void DiscountEnergy_should_calculate_correct_tariff(decimal gasUsage, decimal electricitUsage, decimal expectedResult)
        {
            _tariffData = DataBuilder.DiscountEnergyCreate();
            _calculator = new EnergySaverCalculator(_tariffData);

            var annualCost = _calculator.GetFinalCost(gasUsage, electricitUsage);

            Assert.That(annualCost, Is.EqualTo(expectedResult));
        }

        [TestCase(0, 4000, 439.45)]
        [TestCase(0, 0, 0)]
        [TestCase(2000, 4000, 947.12)]
        [TestCase(1500, 3000, 710.34)]
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
