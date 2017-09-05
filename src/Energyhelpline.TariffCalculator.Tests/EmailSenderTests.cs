using System;
using Energyhelpline.TariffCalculator.Helpers;
using Energyhelpline.TariffCalculator.Models;
using Energyhelpline.TariffCalculator.Tests.Builders;
using NUnit.Framework;

namespace Energyhelpline.TariffCalculator.Tests
{
    [TestFixture]
    public class EmailSenderTests
    {
        private EmailService _emailService;
        private EmailConfigModel _configModel;

        [SetUp]
        public void SetUp()
        {
            _configModel = EmailConfigBuilder.Build();
            _emailService = new EmailService(_configModel);
        }

        [Test]
        public void Should_send_test_email_to_address()
        {
            const string noError = "No Error";
            var error = noError;

            try
            {
                const string message = "wassup?";
                _emailService.SendEmail(message);
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            Assert.That(error, Is.EqualTo(noError));
        }
    }
}
