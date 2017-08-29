using Energyhelpline.TariffCalculator.Models;

namespace Energyhelpline.TariffCalculator.UI
{
    public interface IUserInterface
    {
        void PopulateQuote(int gasUsage, int electricityUsage, string startingDate);
        void EmailQuote();
        string ValidateInput(InputModel input);
    }
}