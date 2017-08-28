using Energyhelpline.TariffCalculator.Models;
using FluentValidation;

namespace Energyhelpline.TariffCalculator.Validation
{
    public class ValueValidator : AbstractValidator<InputModel>
    {
        public ValueValidator()
        {
            RuleFor(value=>value.GasUsage).GreaterThanOrEqualTo(0).WithMessage("Gas Usage must be greater than 0");
            RuleFor(value => value.ElectricityUsage).GreaterThanOrEqualTo(0).WithMessage("Electricity Usage must be greater than 0");
        }
    }
}