namespace Energyhelpline.TariffCalculator.Tests
{
    public static class DataBuilder
    {
        public static TariffData EnergySaverCreate()
        {
            return new TariffData
            {
                InitialGasRate = 0.25M,
                FinalGasRate = 0.50M,
                InitialElectricityRate = 0.30M,
                FinalElectricityRate = 0.60M,
                ExpirationDate = "2017/9/1"
            };
        }

        public static TariffData DiscountEnergyCreate()
        {
            return new TariffData
            {
                InitialGasRate = 0.20M,
                FinalGasRate = 0.75M,
                InitialElectricityRate = 0.20M,
                FinalElectricityRate = 0.90M,
                ExpirationDate = "2017/10/10"
            };
        }

        public static TariffData SaveOnline()
        {
            return new TariffData
            {
                InitialGasRate = 0.25M,
                FinalGasRate = 0.60M,
                InitialElectricityRate = 0.10M,
                FinalElectricityRate = 1.00M,
                ExpirationDate = "2018/8/23"
            };
        }

        public static TariffData Standard()
        {
            return new TariffData
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