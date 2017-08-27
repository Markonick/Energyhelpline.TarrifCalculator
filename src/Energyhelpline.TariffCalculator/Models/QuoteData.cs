namespace Energyhelpline.TariffCalculator.Models
{
    public class QuoteData
    {
        public string DateIssued { get; set; }
        public int GasUsage { get; set; }
        public int ElectricityUsage { get; set; }
        public string CheapestTariff { get; set; }
        public decimal AnnualCost { get; set; }
    }
}