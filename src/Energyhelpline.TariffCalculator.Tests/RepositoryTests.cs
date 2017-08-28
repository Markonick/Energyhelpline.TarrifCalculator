using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Energyhelpline.TariffCalculator.Helpers;
using Energyhelpline.TariffCalculator.Models;
using Energyhelpline.TariffCalculator.Repositories;
using Moq;
using NUnit.Framework;

namespace Energyhelpline.TariffCalculator.Tests
{
    [TestFixture]
    public class RepositoryTests
    {
        private readonly string _fileName = "testFileName";
        private Mock<ICsvFileReader> _csvReader;
        private CsvQuoteRepository _repository;

        [SetUp]
        public void SetUp()
        {
            _csvReader = new Mock<ICsvFileReader>();
            _repository = new CsvQuoteRepository(_csvReader.Object, _fileName);
        }

        [Test]
        public void Should_get_expected_quotes_from_file()
        {
            const string date1 = "15/10/2017";
            const string date2 = "01/11/2017";
            const string date3 = "05/12/2017";
            const string date4 = "30/09/2017";

            _csvReader.Setup(rdr => rdr.ReadQuotesFromCsv(_fileName)).Returns(TariffDataBuilder.Build(date1, date2, date3, date4));

            var quotes = _repository.GetQuotes();

            Assert.That(quotes.Count, Is.EqualTo(6));
        }
    }
}
