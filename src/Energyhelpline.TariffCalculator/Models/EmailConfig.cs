namespace Energyhelpline.TariffCalculator.Models
{
    public class EmailConfig
    {
        public string FromAddress { get; set; }
        public string ToAddress { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Subject { get; set; }
        public string SmtpServer { get; set; }
        public int Port { get; set; }
    }
}