using System.Collections.Generic;
using System.IO;
using CsvHelper;
using Energyhelpline.TariffCalculator.Models;

namespace Energyhelpline.TariffCalculator.Helpers
{
    public class CsvFileWriter
    {
        private readonly IList<TariffDataModel> _tariffDataModel;

        public CsvFileWriter(IList<TariffDataModel> tariffDataModel)
        {
            _tariffDataModel = tariffDataModel;
        }

        public void Build(string fileName)
        {
            var file = File.OpenWrite(fileName);
            using (var writer = new StreamWriter(file))
            using (var csv = new CsvWriter(writer))
            {
                csv.WriteField("Tariff name");
                csv.WriteField("Gas initial unit rate (£/kWh)");
                csv.WriteField("Gas final unit rate (£/kWh)");
                csv.WriteField("Electricity initial unit rate (£/kWh)");
                csv.WriteField("Electricity final unit rate (£/kWh)");
                csv.WriteField("Initial rate expiration date (DD/MM/YYYY)");
                csv.NextRecord();

                foreach (var quote in _tariffDataModel)
                {
                    csv.WriteRecord(quote);
                }
            };
        }
    }
}