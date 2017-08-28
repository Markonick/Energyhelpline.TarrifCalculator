using System.Collections.Generic;
using Energyhelpline.TariffCalculator.Helpers;
using Energyhelpline.TariffCalculator.Models;

namespace Energyhelpline.TariffCalculator.Repositories
{
    public class CsvQuoteRepository : IRepository
    {
        private readonly ICsvFileReader _reader;
        private readonly string _fileName;

        public CsvQuoteRepository(ICsvFileReader reader, string fileName)
        {
            _reader = reader;
            _fileName = fileName;
        }

        public IList<TariffData> GetQuotes()
        {
            return _reader.ReadQuotesFromCsv(_fileName);
        }
    }
}