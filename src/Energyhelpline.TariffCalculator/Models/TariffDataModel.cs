﻿namespace Energyhelpline.TariffCalculator.Models
{
    public class TariffDataModel
    {
        public string Name { get; set; }
        public decimal InitialGasRate { get; set; }
        public decimal? FinalGasRate { get; set; }
        public decimal InitialElectricityRate { get; set; }
        public decimal? FinalElectricityRate { get; set; }
        public string ExpirationDate { get; set; }
    }
}