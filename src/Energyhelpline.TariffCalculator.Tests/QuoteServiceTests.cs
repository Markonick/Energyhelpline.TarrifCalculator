using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Energyhelpline.TariffCalculator.Models;
using Energyhelpline.TariffCalculator.Repositories;
using Energyhelpline.TariffCalculator.Services;
using Moq;
using NUnit.Framework;

namespace Energyhelpline.TariffCalculator.Tests
{
    [TestFixture]
    public class QuoteServiceTests
    {
        private QuoteService _quoteService;
        private Mock<IQuoteRepository> _repository;

        [SetUp]
        public void SetUp()
        {
            _repository = new Mock<IQuoteRepository>();
            _quoteService = new QuoteService(_repository.Object);
        }

        [Test]
        public void Should_choose_best_quote_amongs_list()
        {
            IList<TariffData> listOfQuotes = new List<TariffData>()
            {
                new TariffData { InitialGasRate = 0.1M, FinalGasRate = 0.2M, InitialElectricityRate = 0.15M, FinalElectricityRate = 0.25M, ExpirationDate = DateTime.Today.ToString("yyyy/M/D"), },
                new TariffData { InitialGasRate = 0.11M, FinalGasRate = null, InitialElectricityRate = 0.15M, FinalElectricityRate = null, ExpirationDate = "None", },
                new TariffData { InitialGasRate = 0.4M, FinalGasRate = 0.45M, InitialElectricityRate = 0.12M, FinalElectricityRate = 0.22M, ExpirationDate = DateTime.Today.ToString("yyyy/M/D"), },
                new TariffData { InitialGasRate = 0.15M, FinalGasRate = 0.25M, InitialElectricityRate = 0.15M, FinalElectricityRate = 0.25M, ExpirationDate = DateTime.Today.ToString("yyyy/M/D"), },
                new TariffData { InitialGasRate = 0.23M, FinalGasRate = null, InitialElectricityRate = 0.15M, FinalElectricityRate = null, ExpirationDate = "None", },
                new TariffData { InitialGasRate = 0.11M, FinalGasRate = 0.21M, InitialElectricityRate = 0.19M, FinalElectricityRate = 0.25M, ExpirationDate = DateTime.Today.ToString("yyyy/M/D"), },
            };

            _repository.Setup(repo => repo.GetQuotes()).Returns(listOfQuotes);
            var bestQuote = _quoteService.GetBestQuote();

            Assert.That(bestQuote, Is.EqualTo(2222));
        }
    }
}
