using System;
using NUnit.Framework;
using static System.Decimal;

namespace Energyhelpline.TariffCalculator.Tests
{
    [TestFixture]
    public class TariffCalculatorTests
    {
        private ITariffCalculator _tariffCalculator;

        [SetUp]
        public void SetUp()
        {
        }

        [TestCase(2000, 4000, 0.25, 0.5, 0.3, 0.6, "01/01/2018", 2015.55)]
        [TestCase(1500, 3000, 0.25, 0.5, 0.3, 0.6, "01/01/2018", 2015.55)]
        public void EnergySaver_should_calculate_correct_tariff(int gasUsage, int electricitUsage, decimal initialGasRate, decimal finalGasRate, decimal initialElectricityRate, decimal finalElectricityRate, DateTime expirationDate, decimal expectedResult)
        {
            const int daysPerYear = 365;
            //arrange
            /*var daysBeforeExpiration = (int)(expirationDate - DateTime.Today).TotalDays + 24;
            var daysAfterExpiration = 365 - daysBeforeExpiration;

            var initialGasCost = Divide(daysBeforeExpiration, daysPerYear) * gasUsage * initialGasRate;
            var initialElectricityCost = Divide(daysBeforeExpiration, daysPerYear) * electricitUsage * initialElectricityRate;

            var finalGasCost = Divide(daysAfterExpiration, daysPerYear) * gasUsage * finalGasRate;
            var finalElectricityCost = Divide(daysAfterExpiration, daysPerYear) * electricitUsage * finalElectricityRate;*/

            var annualCost = _tariffCalculator.GetFinalCost();

            //act
            //var annualCost = Math.Round(initialGasCost + finalGasCost + initialElectricityCost + finalElectricityCost, 2);

            //assert
            Assert.That(annualCost, Is.EqualTo(expectedResult));
        }
    }
}
