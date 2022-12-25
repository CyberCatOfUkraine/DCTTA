using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCTTA.Mappers
{
    internal static class ScraperMapper
    {
        public static List<DCTTA.Models.Currency> Convert(this List<ApiScraper.Models.CryptocurrencyDetails> currencies)
        {
            if (currencies == null)
            {
                return new();
            }
            return (from currency in currencies
                    select new DCTTA.Models.Currency(
                currency.Code,
                currency.Code,
                currency.Price,
                currency.Volume,
                currency.PriceChange,
                currency.Markets.Convert(),
                currency.BaseId,
                currency.Rank)
                    ).ToList();
        }
        public static List<DCTTA.Models.Market> Convert(this List<ApiScraper.Models.Market> markets)
        {
            if (markets == null)
            {
                return new();
            }
            return (from market in markets select new DCTTA.Models.Market(market.Name, market.Price)).ToList();
        }
    }
}
