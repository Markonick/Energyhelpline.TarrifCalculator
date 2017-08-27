﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Energyhelpline.TariffCalculator.Models;
using Energyhelpline.TariffCalculator.Repositories;
using Energyhelpline.TariffCalculator.Services;

namespace Energyhelpline.TariffCalculator.Services
{
    public class QuoteService : IQuoteService
    {
        private readonly IQuoteRepository _quoteRepository;

        public QuoteService(IQuoteRepository quoteRepository)
        {
            _quoteRepository = quoteRepository;
        }

        public QuoteData GetBestQuote()
        {
            var quotes = _quoteRepository.GetQuotes();

            foreach (var quote in quotes)
            {
                
            }

            return null;
        }
    }
}
