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

        public QuoteService(IRepository quoteRepository)
        {
            _quoteRepository = quoteRepository;
        }

        public QuoteDataModel GetBestQuote(int gasUsage, int electricityUsage, string startingDate)
        {
            var quotes = _quoteRepository.GetQuotes();
            var tariff = new TariffDataModel();
            var calculators = new List<ICalculator>
            {
                new EnergySaverCalculator(inputModel, tariffDataModel),
                new DiscountEnergyCalculator(),
                new StandardCalculator(),
                new SaveOnlineCalculator()
            };

            foreach (var quote in quotes)
            {
                if(quote.Name == "");
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