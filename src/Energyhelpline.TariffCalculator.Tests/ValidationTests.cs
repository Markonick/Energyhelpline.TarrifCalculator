using System.Collections.Generic;
using Energyhelpline.TariffCalculator.Models;
using Energyhelpline.TariffCalculator.Validation;
using FluentValidation;
using NUnit.Framework;

namespace Energyhelpline.TariffCalculator.Tests
{
    [TestFixture]
    public class ValidationTests
    {
        private InputValidator _inputValidator;

        [SetUp]
        public void SetUp()
        {
        }
        
        [TestCase(-1, 1000, "31/09/2017")]
        [TestCase(-2222, 0, "31/09/2017")]
        public void ValueValidator_should_assert_when_gasUsage_is_negative(int gas, int electricity, string date)
        {

            var inputModel = new InputModel
            {
                GasUsage = gas,
                ElectricityUsage = electricity,
                StartingDate = date
            };

            var validators = new List<AbstractValidator<InputModel>>
            {
                new ValueValidator()
            };

            _inputValidator = new InputValidator(validators);

            var result = _inputValidator.GetResult(inputModel);

            Assert.That(result, Is.EqualTo("Gas Usage must be greater than 0"));
        }

        [TestCase(1000, -1, "31/09/2017")]
        [TestCase(0, -1, "31/09/2017")]
        public void ValueValidator_should_assert_when_electricityUsage_is_negative(int gas, int electricity, string date)
        {

            var inputModel = new InputModel
            {
                GasUsage = gas,
                ElectricityUsage = electricity,
                StartingDate = date
            };

            var validators = new List<AbstractValidator<InputModel>>
            {
                new ValueValidator()
            };

            _inputValidator = new InputValidator(validators);

            var result = _inputValidator.GetResult(inputModel);

            Assert.That(result, Is.EqualTo("Electricity Usage must be greater than 0"));
        }

        [TestCase(1000, 1, "30/09/2017")]
        [TestCase(0, 1, "30/09/2017")]
        public void ValueValidator_should_return_success_when_usage_is_not_negative(int gas, int electricity, string date)
        {
            var inputModel = new InputModel
            {
                GasUsage = gas,
                ElectricityUsage = electricity,
                StartingDate = date
            };

            var validators = new List<AbstractValidator<InputModel>>
            {
                new ValueValidator()
            };

            _inputValidator = new InputValidator(validators);

            var result = _inputValidator.GetResult(inputModel);

            Assert.That(result, Is.EqualTo("Passed input validations!"));
        }

        [TestCase(1110, 1111, "3177/09/20")]
        [TestCase(0, 1, "1-09-20")]
        [TestCase(1000, 1, "09-2017")]
        public void DateValidator_should_assert_when_date_not_in_DDMMMYYYY_format(int gas, int electricity, string date)
        {

            var inputModel = new InputModel
            {
                GasUsage = gas,
                ElectricityUsage = electricity,
                StartingDate = date
            };

            var validators = new List<AbstractValidator<InputModel>>
            {
                new DateValidator()
            };

            _inputValidator = new InputValidator(validators);

            var result = _inputValidator.GetResult(inputModel);

            Assert.That(result, Is.EqualTo("Date has to be in dd/MM/yyyy format"));
        }

        [TestCase(1000, 1, "")]
        public void DateValidator_should_assert_when_date_is_empty(int gas, int electricity, string date)
        {

            var inputModel = new InputModel
            {
                GasUsage = gas,
                ElectricityUsage = electricity,
                StartingDate = date
            };

            var validators = new List<AbstractValidator<InputModel>>
            {
                new DateValidator()
            };

            _inputValidator = new InputValidator(validators);

            var result = _inputValidator.GetResult(inputModel);

            Assert.That(result, Is.EqualTo("Date cannot be null or empty"));
        }

        [TestCase(1000, 1, "30/09/2017")]
        public void ValueValidator_should_return_success_when_date_is_correct(int gas, int electricity, string date)
        {
            var inputModel = new InputModel
            {
                GasUsage = gas,
                ElectricityUsage = electricity,
                StartingDate = date
            };

            var validators = new List<AbstractValidator<InputModel>>
            {
                new ValueValidator()
            };

            _inputValidator = new InputValidator(validators);

            var result = _inputValidator.GetResult(inputModel);

            Assert.That(result, Is.EqualTo("Passed input validations!"));
        }
    }
}
