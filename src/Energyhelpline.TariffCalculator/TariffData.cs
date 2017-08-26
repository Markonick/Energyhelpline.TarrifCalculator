using System;

namespace Energyhelpline.TariffCalculator
{
    public class TariffData
    {
        public decimal InitialGasRate { get; set; }
        public decimal? FinalGasRate { get; set; }
        public decimal InitialElectricityRate { get; set; }
        public decimal? FinalElectricityRate { get; set; }
        public string ExpirationDate { get; set; }
    }
}