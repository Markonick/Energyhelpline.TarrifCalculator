using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper;
using Energyhelpline.TariffCalculator.Models;

namespace Energyhelpline.TariffCalculator.Helpers
{
    public static class CsvDataFileBuilder
    {
        public static IList<TariffData> Build(string fileName)
        {
            const string date1 = "15/10/2017";
            const string date3 = "01/11/2017";
            const string date4 = "05/12/2017";
            const string date6 = "30/09/2017";

            var listOfQuotes = TariffDataBuilder.Build(date1, date3, date4, date6);
            
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

                foreach (var quote in listOfQuotes)
                {
                    csv.WriteRecord(quote);
                }
            };

            return listOfQuotes;
        }
    }
}