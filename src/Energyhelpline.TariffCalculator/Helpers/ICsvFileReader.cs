using System.Collections.Generic;
using Energyhelpline.TariffCalculator.Models;

namespace Energyhelpline.TariffCalculator.Helpers
{
    public interface ICsvFileReader
    {
        IList<TariffData> ReadQuotesFromCsv(string fileName);
    }
}
