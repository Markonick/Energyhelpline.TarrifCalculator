using Energyhelpline.TariffCalculator.Helpers;
using Energyhelpline.TariffCalculator.Tests.Builders;
using Xunit;

namespace Energyhelpline.TariffCalculator.Tests.Integration
{
    public class CsvReaderTests
    {
        private readonly CsvFileReader _reader;
        private const string FileName = "TestTable";

        public CsvReaderTests()
        {
            _reader = new CsvFileReader();
        }

        [Fact]
        public void CsvFileReader_should_read_expected_quotes_from_file()
        {
            var result = _reader.Read(FileName);

            Assert.Equal(result.Count, 8);
            Assert.Equal(result[0].Name, "Energy Saver");
            Assert.Equal(result[1].Name, "Discount Energy"); 
            Assert.Equal(result[2].Name, "Standard");
            Assert.Equal(result[3].Name, "Save Online");
            Assert.Equal(result[4].Name, "Other1");
            Assert.Equal(result[5].Name, "Other2");
            Assert.Equal(result[6].Name, "Other3");
            Assert.Equal(result[7].Name, "Other4");
            Assert.Equal(result[0].InitialGasRate, 0.25M);
            Assert.Equal(result[1].InitialGasRate, 0.20M);
            Assert.Equal(result[2].InitialGasRate, 0.65M);
            Assert.Equal(result[3].InitialGasRate, 0.25M);
            Assert.Equal(result[4].InitialGasRate, 0.15M);
            Assert.Equal(result[5].InitialGasRate, 0.25M);
            Assert.Equal(result[6].InitialGasRate, 0.30M);
            Assert.Equal(result[7].InitialGasRate, 0.20M);
            Assert.Equal(result[0].InitialElectricityRate, 0.10M );
            Assert.Equal(result[1].InitialElectricityRate, 0.10M);
            Assert.Equal(result[2].InitialElectricityRate, 0.10M);
            Assert.Equal(result[3].InitialElectricityRate, 0.25M);
            Assert.Equal(result[0].InitialElectricityRate, 0.15M);
            Assert.Equal(result[1].InitialElectricityRate, 0.25M);
            Assert.Equal(result[2].InitialElectricityRate, 0.21M);
            Assert.Equal(result[3].InitialElectricityRate, 0.11M);
        }
    }
}