using Energyhelpline.TariffCalculator.Models;

namespace Energyhelpline.TariffCalculator.Validation
{
    public interface IInputValidator
    {
        string GetResult(InputModel input);
    }
}