using System.Collections.Generic;
using Energyhelpline.TariffCalculator.Models;

namespace Energyhelpline.TariffCalculator.Helpers
{
    public interface ICsvFileReader
    {
        IList<TariffDataModel> ReadQuotesFromCsv(string fileName);
    }
}
