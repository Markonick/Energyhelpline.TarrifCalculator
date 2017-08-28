using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Energyhelpline.TariffCalculator.Models;
using FluentValidation;

namespace Energyhelpline.TariffCalculator.Validation
{
    public class InputValidator : IInputValidator
    {
        private readonly IList<AbstractValidator<InputModel>> _validators;

        public InputValidator(IList<AbstractValidator<InputModel>> validators)
        {
            _validators = validators;
        }

        public string GetResult(InputModel input)
        {
            try
            {
                foreach (var validator in _validators)
                {
                    var validationResult = validator.Validate(input);

                    if (!validationResult.IsValid)
                    {
                        return validationResult.Errors.First().ErrorMessage;
                    }
                }

                return "Passed input validations!";
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}