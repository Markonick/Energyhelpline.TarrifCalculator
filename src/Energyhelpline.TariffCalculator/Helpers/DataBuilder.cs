using Energyhelpline.TariffCalculator.Models;

namespace Energyhelpline.TariffCalculator.Helpers
{
    public static class DataBuilder
    {
        public static TariffDataModel EnergySaverCreate()
        {
            return new TariffDataModel
            {
                InitialGasRate = 0.25M,
                FinalGasRate = 0.50M,
                InitialElectricityRate = 0.30M,
                FinalElectricityRate = 0.60M,
                ExpirationDate = "31/12/2017"
            };
        }

        public static TariffDataModel DiscountEnergyCreate()
        {
            return new TariffDataModel
            {
                InitialGasRate = 0.20M,
                FinalGasRate = 0.75M,
                InitialElectricityRate = 0.20M,
                FinalElectricityRate = 0.90M,
                ExpirationDate = "31/12/2017"
            };
        }

        public static TariffDataModel SaveOnline()
        {
            return new TariffDataModel
            {
                InitialGasRate = 0.25M,
                FinalGasRate = 0.60M,
                InitialElectricityRate = 0.10M,
                FinalElectricityRate = 1.00M,
                ExpirationDate = "31/12/2017"
            };
        }

        public static TariffDataModel Standard()
        {
            return new TariffDataModel
            {
                InitialGasRate = 0.25M,
                FinalGasRate = null,
                InitialElectricityRate = 0.30M,
                FinalElectricityRate = null,
                ExpirationDate = "None"
            };
        }
    }
}