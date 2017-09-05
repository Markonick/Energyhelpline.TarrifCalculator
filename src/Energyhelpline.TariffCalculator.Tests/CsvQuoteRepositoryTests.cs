using Energyhelpline.TariffCalculator.Helpers;
using Energyhelpline.TariffCalculator.Repositories;
using Energyhelpline.TariffCalculator.Tests.Builders;
using Moq;
using Xunit;

namespace Energyhelpline.TariffCalculator.Tests
{
    public class CsvQuoteRepositoryTests
    {
        private const string FileName = "testFileName";
        private readonly Mock<ICsvFileReader> _csvReader;
        private readonly CsvQuoteRepository _repository;
        
        public CsvQuoteRepositoryTests()
        {
            _csvReader = new Mock<ICsvFileReader>();
            _repository = new CsvQuoteRepository(_csvReader.Object, FileName);
        }

        [Fact]
        public void Should_get_expected_quotes_from_file()
        {
            const string date1 = "15/10/2017";
            const string date2 = "01/11/2017";
            const string date3 = "05/12/2017";
            const string date4 = "30/09/2017";

            _csvReader.Setup(rdr => rdr.Read(FileName)).Returns(TariffDataBuilder.Build(date1, date2, date3, date4));

            var quotes = _repository.GetQuotes();

            Assert.Equal(quotes.Count, 6);
        }
    }
}
