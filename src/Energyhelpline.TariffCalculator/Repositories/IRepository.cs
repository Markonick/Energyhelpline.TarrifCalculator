using System.Collections.Generic;
using Energyhelpline.TariffCalculator.Models;

namespace Energyhelpline.TariffCalculator.Repositories
{
    public interface IRepository
    {
        IList<TariffData> GetQuotes();
    }
}