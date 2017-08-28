using Energyhelpline.TariffCalculator.Helpers;
using Energyhelpline.TariffCalculator.Repositories;
using Energyhelpline.TariffCalculator.Services;
using Energyhelpline.TariffCalculator.Strategies;
using Moq;
using NUnit.Framework;

namespace Energyhelpline.TariffCalculator.Tests
{
    [TestFixture]
    public class QuoteServiceTests
    {
        private QuoteService _quoteService;
        private Mock<IRepository> _repository;
        private Mock<IStrategyResolver> _strategyResolver;
        private const string _filelName = "testFileName";

        [SetUp]
        public void SetUp()
        {
            _repository = new Mock<IRepository>(_filelName);
            _strategyResolver = new Mock<IStrategyResolver>();
            _quoteService = new QuoteService(_repository.Object, _strategyResolver.Object);
        }

        [TestCase(1500, 3000, "30/09/2017")]
        [TestCase(2000, 4000, "30/09/2017")]
        public void QuoteService_should_choose_best_quote_among_tariff_list_with_given_power_usages(int gasUsage, int electricityUsage, string startingDate)
        {
            const string date1 = "15/10/2017";
            const string date3 = "01/11/2017";
            const string date4 = "05/12/2017";
            const string date6 = "30/09/2017";

            var listOfQuotes = TariffDataBuilder.Build(date1, date3, date4, date6);

            _repository.Setup(repo => repo.GetQuotes()).Returns(listOfQuotes);
            //_strategyResolver.Setup(strategy => strategy.GetEnumFromStrategy("")).Returns(TariffStrategyEnum.EnergySaver);
            //_strategyResolver.Setup(strategy => strategy.GetStrategy()).Returns(TariffStrategyEnum.EnergySaver);

            var bestQuote = _quoteService.GetBestQuote(gasUsage, electricityUsage, startingDate);

            Assert.That(bestQuote, Is.EqualTo(2222));
        }
    }
}
