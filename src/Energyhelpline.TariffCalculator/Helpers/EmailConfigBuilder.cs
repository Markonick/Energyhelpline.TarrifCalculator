using Energyhelpline.TariffCalculator.Models;

namespace Energyhelpline.TariffCalculator.Helpers
{
    public static class EmailConfigBuilder
    {
        public static EmailConfig Build()
        {
            return new EmailConfig
            {
                FromAddress = "nicolas.markos@gmail.com",
                ToAddress = "nicolas.markos@gmail.com",
                Username = "nicolas.markos",
                Password = "password",
                Subject = "Wassup?",
                Message = "As I said, wassup?",
                SmtpServer = "smtp.gmail.com",
                Port = 587
            };
        }
    }
}