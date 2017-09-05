using System;
using System.Collections.Generic;
using System.Linq;
using Energyhelpline.TariffCalculator.Models;
using Energyhelpline.TariffCalculator.Repositories;
using Energyhelpline.TariffCalculator.Strategies;

namespace Energyhelpline.TariffCalculator.Services
{
    public class QuoteService : IQuoteService
    {
        private readonly IRepository _quoteRepository;
        private readonly IStrategyResolver _strategyResolver;

        public QuoteService(IRepository quoteRepository, IStrategyResolver strategyResolver)
        {
            _quoteRepository = quoteRepository;
            _strategyResolver = strategyResolver;
        }

        public QuoteDataModel GetBestQuote(int gasUsage, int electricityUsage, string startingDate)
        {
            var tariffs = _quoteRepository.GetQuotes();
            var tariff = new TariffDataModel();
            var calculators = new List<ICalculator>
            {
                new EnergySaverCalculator(),
            };

            foreach (var quote in quotes)
            {
                if(quote.);
            }

            var orderedList = quoteList.OrderBy(x => x.AnnualCost);
            
            return orderedList.FirstOrDefault();
        }

        private static QuoteDataModel Mapper(TariffDataModel quote, int gasUsage, int electricityUsage, decimal cost)
        {
            return new QuoteDataModel
            {
                CheapestTariff = quote.Name,
                DateTimeIssued = DateTime.Now,
                GasUsage = gasUsage,
                ElectricityUsage = electricityUsage,
                AnnualCost = cost
            };
        }
    }
}