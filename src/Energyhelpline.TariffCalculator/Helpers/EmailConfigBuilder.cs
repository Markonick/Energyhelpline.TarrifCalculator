using Energyhelpline.TariffCalculator.Models;

namespace Energyhelpline.TariffCalculator.Helpers
{
    public static class EmailConfigBuilder
    {
        public static EmailConfig Build()
        {
            return new EmailConfig
            {
                FromAddress = "dudubrain@dudu.com",
                ToAddress = "dudubrain@dudu.com",
                Username = "nicolas.markos",
                Password = "TheElvis23",
                Subject = "Wassup?",
                Message = "As I said, wassup?",
                SmtpServer = "smtp.gmail.com",
                Port = 587
            };
        }
    }
}