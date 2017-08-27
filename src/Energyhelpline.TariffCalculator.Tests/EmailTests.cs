using Energyhelpline.TariffCalculator.Helpers;
using Energyhelpline.TariffCalculator.Models;
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
}
