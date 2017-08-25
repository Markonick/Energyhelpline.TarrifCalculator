using System;
using NUnit.Framework;
using static System.Decimal;

namespace Energyhelpline.TariffCalculator.Tests
{
    [TestFixture]
    public class TariffCalculatorTests
    {
        [SetUp]
        public void SetUp()
        {
        }

        //[TestCase(0.2, 0.4, 0.20, 0.40, "01/01/2018", 100)]
        [TestCase(1500, 3000, 0.25, 0.5, 0.3, 0.6, "01/01/2018", 2015.55)]
        public void EnergySaver_should_calculate_correct_tariff(int gasUsage, int electricitUsage, decimal initialGasRate, decimal finalGasRate, decimal initialElectricityRate, decimal finalElectricityRate, DateTime expirationDate, decimal expectedResult)
        {
            const int daysPerYear = 365;
            //arrange
            var daysBeforeExpiration = (int)(expirationDate - DateTime.Today).TotalDays + 24;
            var daysAfterExpiration = 365 - daysBeforeExpiration;

            var initialGasCost = Divide(daysBeforeExpiration, daysPerYear) * gasUsage * initialGasRate;
            var initialElectricityCost = Divide(daysBeforeExpiration, daysPerYear) * electricitUsage * initialElectricityRate;

            var finalGasCost = Divide(daysAfterExpiration, daysPerYear) * gasUsage * finalGasRate;
            var finalElectricityCost = Divide(daysAfterExpiration, daysPerYear) * electricitUsage * finalElectricityRate;

            //act
            var annualCost = Math.Round(initialGasCost + finalGasCost + initialElectricityCost + finalElectricityCost, 2);

            //assert
            Assert.That(annualCost, Is.EqualTo(expectedResult));
        }
    }
}
