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

        public QuoteData GetBestQuote(int gasUsage, int electricityUsage, string startingDate)
        {
            var quotes = _quoteRepository.GetQuotes();
            var quoteList = new List<QuoteData>();

            foreach (var quote in quotes)
            {
                var strategy = _strategyResolver.GetEnumFromStrategy(quote.Name);
                var cost = _strategyResolver.GetStrategy(strategy, quote).GetFinalCost(gasUsage, electricityUsage, startingDate);

                quoteList.Add(Mapper(quote, gasUsage, electricityUsage, cost));
            }

            var orderedList = quoteList.OrderBy(x => x.AnnualCost);
            
            return orderedList.FirstOrDefault();
        }

        private static QuoteData Mapper(TariffData quote, int gasUsage, int electricityUsage, decimal cost)
        {
            return new QuoteData
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