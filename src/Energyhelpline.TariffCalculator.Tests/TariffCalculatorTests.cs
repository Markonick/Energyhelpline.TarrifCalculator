using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        [TestCase(0.25, 0.5, 0.30, 0.60, 01/01/2018)]
        public void EnergySaver_should_calculate_correct_tariff(decimal initialGasRate, decimal finalGasRate, decimal initialElectricityRate, decimal finalElectricityRate, DateTime expirationDate, decimal expectedResult)
        {
            //arrange
            var daysBeforeExpiration = 0; //TODO
            var daysAfterExpiration = 0;//TODO

            //act
            var initialGasCost = daysBeforeExpiration * initialGasRate;
            var finalGasCost = daysAfterExpiration * finalGasRate;
            var initialElectricityCost = daysBeforeExpiration * initialElectricityRate;
            var finalElectricityCost = daysAfterExpiration * finalElectricityRate;
            var annualCost = initialGasCost + finalGasCost + initialElectricityCost + finalElectricityCost;

            //assert
            Assert.That(annualCost, Is.EqualTo(expectedResult));
        }
    }
}
