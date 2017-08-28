﻿using Energyhelpline.TariffCalculator.Helpers;
using Energyhelpline.TariffCalculator.Models;
using Energyhelpline.TariffCalculator.Services;
using Energyhelpline.TariffCalculator.UI;
using Moq;
using NUnit.Framework;

namespace Energyhelpline.TariffCalculator.Tests
{
    [TestFixture]
    public class UserInterfaceTests
    {
        private const int GasUsage = 1111;
        private const int ElectricityUsage = 2222;
        private const string CheapestTariff = "Great Tariff";
        private const decimal AnnualCost = 3333;
        private const string StartingDate = "30/9/2017";

        private UserInterface _ui;
        private QuoteData _quoteData;
        private Mock<IQuoteService> _quoteService;
        private Mock<IEmailSender> _emailSender;

        [SetUp]
        public void SetUp()
        {
            _quoteData = QuoteBuilder.Build(GasUsage, ElectricityUsage, CheapestTariff, AnnualCost);
            _quoteService = new Mock<IQuoteService>();

            _emailSender = new Mock<IEmailSender>();
            _ui = new UserInterface(_quoteService.Object, _emailSender.Object, GasUsage, ElectricityUsage, StartingDate);
        }

        [Test]
        public void Should_produce_quote_message_in_the_expected_format()
        {
            _quoteService.Setup(serv => serv.GetBestQuote(GasUsage, ElectricityUsage, StartingDate)).Returns(_quoteData);       
            _emailSender.Setup(snd => snd.SendEmail("somemessage"));

            _ui.PopulateQuote();
            var quoteMessage = _ui.Output;

            var numberOfLines = quoteMessage.Split('\n').Length - 1;

            Assert.That(numberOfLines, Is.EqualTo(5));
        }
    }
}
