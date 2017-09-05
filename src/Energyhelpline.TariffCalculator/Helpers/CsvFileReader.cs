using System.Collections.Generic;
using System.IO;
using Energyhelpline.TariffCalculator.Models;

namespace Energyhelpline.TariffCalculator.Helpers
{
    public class CsvFileReader : ICsvFileReader
    {
        public IList<TariffDataModel> Read(string fileName)
        {
            var quotes = new List<TariffDataModel>();
            var path = Directory.GetCurrentDirectory();
            var pathAndFileName = Path.Combine(path, fileName);

            using (var fs = File.OpenRead(pathAndFileName))
            using (var reader = new StreamReader(fs))
            {
                reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    var tariffData = new TariffDataModel
                    {
                        Name = values[0],
                        InitialGasRate = decimal.Parse(values[1])
                    };

                    if (string.IsNullOrEmpty(values[2]))
                    {
                        tariffData.FinalGasRate = null;
                    }
                    else
                    {
                        tariffData.FinalGasRate = decimal.Parse(values[2]);
                    }

                    tariffData.InitialElectricityRate = decimal.Parse(values[3]);

                    if (string.IsNullOrEmpty(values[4]))
                    {
                        tariffData.FinalElectricityRate = null;
                    }
                    else
                    {
                        tariffData.FinalElectricityRate = decimal.Parse(values[4]);
                    }

                    tariffData.ExpirationDate = values[5];
                    quotes.Add(tariffData);
                }
            }

            return quotes;
        }
    }
}
