using System;
using Energyhelpline.TariffCalculator.Helpers;
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

        private QuoteBuilder _quoteBuilder;
        private UserInterface _ui;
        private Mock<IQuoteService> _quoteService;

        [SetUp]
        public void SetUp()
        {
            _quoteBuilder = new QuoteBuilder(GasUsage, ElectricityUsage, CheapestTariff, AnnualCost);
            _quoteService = new Mock<IQuoteService>();
            _ui = new UserInterface(_quoteService.Object);
        }

        [Test]
        public void Should_print_out_quote_message_in_the_expected_format()
        {
            var quoteData = _quoteBuilder.Build();
            _quoteService.Setup(serv => serv.GetBestQuote()).Returns(quoteData);

            var quoteMessage = _ui.OutputQuote();

            var numberOfLines = quoteMessage.Split('\n').Length - 1;

            Assert.That(numberOfLines, Is.EqualTo(5));
        }
    }
}
