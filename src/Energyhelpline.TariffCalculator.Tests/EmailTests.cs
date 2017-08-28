using System;
using Energyhelpline.TariffCalculator.Helpers;
using Energyhelpline.TariffCalculator.Models;
using NUnit.Framework;

namespace Energyhelpline.TariffCalculator.Tests
{
    [TestFixture]
    public class EmailTests
    {
        private EmailSender _emailSender;
        private EmailConfigModel _configModel;

        [SetUp]
        public void SetUp()
        {
            _configModel = EmailConfigBuilder.Build();
            _emailSender = new EmailSender(_configModel);
        }

        [Test]
        public void Should_send_test_email_to_address()
        {
            const string noError = "No Error";
            var error = noError;

            try
            {
                const string message = "wassup?";
                _emailSender.SendEmail(message);
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            Assert.That(error, Is.EqualTo(noError));
        }
    }
}
