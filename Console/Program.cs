// See https://aka.ms/new-console-template for more information
using ApiScraper.Scrapper;

Console.WriteLine("Hello, World!");


CoinCapScraper scraper = new();
scraper.Initialize();

List<ApiScraper.Models.CryptocurrencyDetails> all = scraper.GetAll;

Console.WriteLine(all.Count);

var first = all[0];
var details = scraper.Get(first.Name);
Console.WriteLine(
    details.Name + " : " +
    details.Code + " : " +
    details.Price + " : " +
    details.BaseId + " : " +
    details.Volume + " : " +
    details.PriceChange
    );
Console.ReadKey();


