using Energyhelpline.TariffCalculator.Helpers;
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

        [TestCase(0, 0, "30/09/2017", 0.0)]
        [TestCase(0, 4000, "30/09/2017", 2097.53)]
        [TestCase(1500, 3000, "30/09/2017", 2228.63)]
        [TestCase(2000, 4000, "30/09/2017", 2971.51)]
        public void EnergySaver_should_calculate_correct_tariff(int gasUsage, int electricitUsage, string startDate, decimal expectedResult)
        {
            _tariffData = DataBuilder.EnergySaverCreate();
            _calculator = new EnergySaverCalculator(_tariffData);

            var annualCost = _calculator.GetFinalCost(gasUsage, electricitUsage, startDate);
            
            Assert.That(annualCost, Is.EqualTo(expectedResult));
        }

        [TestCase(0, 0, "30/09/2017", 0.0)]
        [TestCase(0, 4000, "30/09/2017", 2894.25)]
        [TestCase(1500, 3000, "30/09/2017", 3087.74)]
        [TestCase(2000, 4000, "30/09/2017", 4116.99)]
        public void DiscountEnergy_should_calculate_correct_tariff(int gasUsage, int electricitUsage, string startDate, decimal expectedResult)
        {
            _tariffData = DataBuilder.DiscountEnergyCreate();
            _calculator = new EnergySaverCalculator(_tariffData);

            var annualCost = _calculator.GetFinalCost(gasUsage, electricitUsage, startDate);

            Assert.That(annualCost, Is.EqualTo(expectedResult));
        }

        [TestCase(0, 0, "30/09/2017", 0)]
        [TestCase(0, 4000, "30/09/2017", 3092.6)]
        [TestCase(1500, 3000, "30/09/2017", 3087.12)]
        [TestCase(2000, 4000, "30/09/2017", 4116.16)]
        public void SaveOnline_should_calculate_correct_tariff(int gasUsage, int electricitUsage, string startDate, decimal expectedResult)
        {
            _tariffData = DataBuilder.SaveOnline();
            _calculator = new EnergySaverCalculator(_tariffData);

            var annualCost = _calculator.GetFinalCost(gasUsage, electricitUsage, startDate);

            Assert.That(annualCost, Is.EqualTo(expectedResult));
        }

        [TestCase(0, 0, "30/09/2017", 0)]
        [TestCase(0, 4000, "30/09/2017", 400)]
        [TestCase(1500, 3000, "30/09/2017", 675)]
        [TestCase(2000, 4000, "30/09/2017", 900)]
        public void Standard_should_calculate_correct_tariff(int gasUsage, int electricitUsage, string startDate, decimal expectedResult)
        {
            _tariffData = DataBuilder.SaveOnline();
            _calculator = new StandardCalculator(_tariffData);

            var annualCost = _calculator.GetFinalCost(gasUsage, electricitUsage, startDate);

            Assert.That(annualCost, Is.EqualTo(expectedResult));
        }
    }
}
