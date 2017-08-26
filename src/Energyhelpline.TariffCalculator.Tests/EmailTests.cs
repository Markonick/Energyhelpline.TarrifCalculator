using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;
using NUnit.Framework;

namespace Energyhelpline.TariffCalculator.Tests
{
    [TestFixture]
    public class EmailTests
    {
        private EmailSender _emailSender;
        private EmailConfig _config;

        [SetUp]
        public void SetUp()
        {
            _config = EmailConfigBuilder.Build();
            _emailSender = new EmailSender(_config);
        }

        [Test]
        public void Should_send_test_email_to_address()
        {
            _emailSender.SendEmail();
        }
    }

    public static class EmailConfigBuilder
    {
        public static EmailConfig Build()
        {
            return new EmailConfig()
            {
                FromAddress = "dudubrain@dudu.com",
                ToAddress = "nicolas.markos@gmail.com",
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
