using Energyhelpline.TariffCalculator.Helpers;
using NUnit.Framework;

namespace Energyhelpline.TariffCalculator.Tests
{
    [TestFixture]
    public class CsvReaderTests
    {
        [Test]
        public void CsvFileReader_should_read_expected_quotes_from_file()
        {
            const string fileName = "marketfile";
            var expectedQuotes = CsvDataFileBuilder.Build(fileName);

            var csvFileReader = new CsvFileReader();

            var result = csvFileReader.ReadQuotesFromCsv(fileName);
            Assert.That(result.Count, Is.EqualTo(expectedQuotes.Count));

            for (var i = 0; i < result.Count; i++)
            {
                Assert.That(result[i].ExpirationDate, Is.EqualTo(expectedQuotes[i].ExpirationDate));
                Assert.That(result[i].Name, Is.EqualTo(expectedQuotes[i].Name));
                Assert.That(result[i].InitialGasRate, Is.EqualTo(expectedQuotes[i].InitialGasRate));
                Assert.That(result[i].FinalGasRate, Is.EqualTo(expectedQuotes[i].FinalGasRate));
                Assert.That(result[i].InitialElectricityRate, Is.EqualTo(expectedQuotes[i].InitialElectricityRate));
                Assert.That(result[i].FinalElectricityRate, Is.EqualTo(expectedQuotes[i].FinalElectricityRate));
            }
        }
    }
}