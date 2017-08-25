using System;
using NUnit.Framework;

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
        [TestCase(0.25f, 0.5f, 0.30f, 0.60f, "01/01/2018", 2015.55f)]
        public void EnergySaver_should_calculate_correct_tariff(float initialGasRate, float finalGasRate, float initialElectricityRate, float finalElectricityRate, DateTime expirationDate, float expectedResult)
        {
            const int daysPerYear = 365;
            //arrange
            var daysBeforeExpiration = (int)(expirationDate - DateTime.Today).TotalDays;
            var daysAfterExpiration = 365 - daysBeforeExpiration;

            var initialGasCost = daysBeforeExpiration / (float)daysPerYear * initialGasRate;
            var finalGasCost = daysAfterExpiration / (float)daysPerYear * finalGasRate;
            var initialElectricityCost = daysBeforeExpiration / (float)daysPerYear * initialElectricityRate;
            var finalElectricityCost = daysAfterExpiration / (float)daysPerYear * finalElectricityRate;

            //act
            var annualCost = initialGasCost + finalGasCost + initialElectricityCost + finalElectricityCost;

            //assert
            Assert.That(annualCost, Is.EqualTo(expectedResult));
        }
    }
}
