using Energyhelpline.TariffCalculator.Models;

namespace Energyhelpline.TariffCalculator.Tests.Builders
{
    public static class EmailConfigBuilder
    {
        public static EmailConfigModel Build()
        {
            return new EmailConfigModel
            {
                FromAddress = "nicolas.markos@gmail.com",//change to new source address
                ToAddress = "nicolas.markos@gmail.com", //change to new destination address
                Username = "nicolas.markos",
                Password = "password", // changed to a valid passw
                Subject = "Wassup?",
                SmtpServer = "smtp.gmail.com", // smtp server
                Port = 587
            };
        }
    }
}