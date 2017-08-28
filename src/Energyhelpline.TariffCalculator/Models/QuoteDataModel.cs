using System;

namespace Energyhelpline.TariffCalculator.Models
{
    public class QuoteDataModel
    {
        public string CheapestTariff { get; set; }
        public DateTime DateTimeIssued { get; set; }
        public int GasUsage { get; set; }
        public int ElectricityUsage { get; set; }
        public decimal AnnualCost { get; set; }
    }
}