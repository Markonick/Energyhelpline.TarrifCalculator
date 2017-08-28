using System.Collections.Generic;
using Energyhelpline.TariffCalculator.Models;

namespace Energyhelpline.TariffCalculator.Helpers
{
    public static class TariffDataBuilder
    {
        public static IList<TariffData> Build(string date1, string date3, string date4, string date6)
        {
            IList<TariffData> listOfQuotes = new List<TariffData>()
            {
                new TariffData
                {
                    Name = "Name1",
                    InitialGasRate = 0.1M,
                    FinalGasRate = 0.2M,
                    InitialElectricityRate = 0.15M,
                    FinalElectricityRate = 0.25M,
                    ExpirationDate = date1
                },
                new TariffData
                {
                    Name = "Name2",
                    InitialGasRate = 0.11M,
                    FinalGasRate = null,
                    InitialElectricityRate = 0.15M,
                    FinalElectricityRate = null,
                    ExpirationDate = "None",
                },
                new TariffData
                {
                    Name = "Name3",
                    InitialGasRate = 0.4M,
                    FinalGasRate = 0.45M,
                    InitialElectricityRate = 0.12M,
                    FinalElectricityRate = 0.22M,
                    ExpirationDate = date3
                },
                new TariffData
                {
                    Name = "Name4",
                    InitialGasRate = 0.15M,
                    FinalGasRate = 0.25M,
                    InitialElectricityRate = 0.15M,
                    FinalElectricityRate = 0.25M,
                    ExpirationDate = date4
                },
                new TariffData
                {
                    Name = "Name5",
                    InitialGasRate = 0.23M,
                    FinalGasRate = null,
                    InitialElectricityRate = 0.15M,
                    FinalElectricityRate = null,
                    ExpirationDate = "None",
                },
                new TariffData
                {
                    Name = "Name6",
                    InitialGasRate = 0.11M,
                    FinalGasRate = 0.21M,
                    InitialElectricityRate = 0.19M,
                    FinalElectricityRate = 0.25M,
                    ExpirationDate = date6
                },
            };
            return listOfQuotes;
        }
    }
}