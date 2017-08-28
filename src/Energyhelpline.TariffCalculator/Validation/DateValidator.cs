using System;
using System.Globalization;
using Energyhelpline.TariffCalculator.Models;
using FluentValidation;

namespace Energyhelpline.TariffCalculator.Validation
{
    public class DateValidator : AbstractValidator<InputModel>
    {
        public DateValidator()
        {
            RuleFor(input => input.StartingDate).NotNull().NotEmpty().WithMessage("Date cannot be null or empty");
            RuleFor(input => input.StartingDate).Must(IsValidDate).WithMessage("Invalid date");
            RuleFor(input => input.StartingDate).Must(IsDateInExpectedFormat).WithMessage("Date has to be in dd/MM/yyyy format");
        }

        private static bool IsValidDate(string arg)
        {
            DateTime date;
            return DateTime.TryParse(arg, out date);
        }

        private static bool IsDateInExpectedFormat(string arg)
        {
            DateTime date;
            return DateTime.TryParseExact(arg,  "dd/MM/yyyy", null, DateTimeStyles.None, out date);
        }
    }
}