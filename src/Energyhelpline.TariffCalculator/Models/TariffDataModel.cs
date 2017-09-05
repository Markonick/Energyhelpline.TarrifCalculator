using System;

namespace Energyhelpline.TariffCalculator.Models
{
    public class TariffDataModel
    {
        public TariffStrategyEnum Name { get; set; }
        public decimal InitialGasRate { get; set; }
        public decimal? FinalGasRate { get; set; }
        public decimal InitialElectricityRate { get; set; }
        public decimal? FinalElectricityRate { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}