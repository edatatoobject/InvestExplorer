using System;
using System.Linq;
using System.Threading.Tasks;
using InvestExplorer.Domain.Entities;
using InvestExplorer.Domain.Entities.Dictionary;
using InvestExplorer.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace InvestExplorer.Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedSampleValue(ApplicationDbContext context)
        {
            
            if (!context.Currencies.Any())
            {
                context.Currencies.Add(new Currency { Id = 1, Code = "USD" });
                context.Currencies.Add(new Currency { Id = 2, Code = "RUB" });
            }

            if (!context.Countries.Any())
            {
                context.Countries.Add(new Country { Id = 1, Name = "Russia" });
                context.Countries.Add(new Country { Id = 2, Name = "USA" });
            }

            if (!context.Industries.Any())
            {
                context.Industries.Add(new Industry { Id = 1, Symbol = "It" });
                context.Industries.Add(new Industry { Id = 2, Symbol = "Finance" });
                context.Industries.Add(new Industry { Id = 3, Symbol = "Telecommunications" });
                context.Industries.Add(new Industry { Id = 4, Symbol = "Oil and gas" });
                context.Industries.Add(new Industry { Id = 5, Symbol = "Extraction of minerals" });
                context.Industries.Add(new Industry { Id = 6, Symbol = "Tecnology" });
            }

            if (!context.Issuers.Any())
            {
                context.Issuers.Add(new Issuer { Id = 1, Name = "Yandex", CountryId = 1, IndustryId = 1 });
                context.Issuers.Add(new Issuer { Id = 2, Name = "Sberbank", CountryId = 1, IndustryId = 2 });
                context.Issuers.Add(new Issuer { Id = 3, Name = "MTC", CountryId = 1, IndustryId = 3 });
                context.Issuers.Add(new Issuer { Id = 4, Name = "SurgutGas", CountryId = 1, IndustryId = 4 });
                context.Issuers.Add(new Issuer { Id = 5, Name = "Alrosa", CountryId = 1, IndustryId = 5 });
                context.Issuers.Add(new Issuer { Id = 6, Name = "Apple", CountryId = 2, IndustryId = 6 });
            }

            if (!context.Exchanges.Any())
            {
                context.Exchanges.Add(new Exchange { Id = 1, Code = "MOEX", Name = "Moscow Exchange" });
            }

            if (!context.Bonds.Any())
            {
                context.Bonds.Add(new Bond
                {
                    Id = 1, CurrencyId = 2, ExchangeId = 1, IssuerId = 2, LotSize = 10,
                    StartPeriod = DateTime.Parse("9/29/2018"), Name = "Sber 001P-SBER15", Isin = "RU000A101C89", Ticker = "RU000A101C89", AssetId = "RU000A101C89",
                    BondType = BondType.Municipal,
                });
                context.Bonds.Add(new Bond
                {
                    Id = 2, CurrencyId = 2, ExchangeId = 1, IssuerId = 1, LotSize = 10,
                    StartPeriod = DateTime.Parse("9/29/2018"), Name = "Ydx 015P-Ydx44", Isin = "RU000A331C53", Ticker = "RU000A331C53", AssetId = "RU000A331C53",
                    BondType = BondType.Corporate,
                });
                context.Bonds.Add(new Bond
                {
                    Id = 3, CurrencyId = 2, ExchangeId = 1, IssuerId = 3, LotSize = 10,
                    StartPeriod = DateTime.Parse("9/29/2018"), Name = "MTC 022P-MT15", Isin = "RU000A551C22", Ticker = "RU000A551C22", AssetId = "RU000A551C22",
                    BondType = BondType.Corporate,
                });
                context.Bonds.Add(new Bond
                {
                    Id = 4, CurrencyId = 2, ExchangeId = 1, IssuerId = 4, LotSize = 10,
                    StartPeriod = DateTime.Parse("9/29/2018"), Name = "SG 066P-SG15", Isin = "RU000A845C09", Ticker = "RU000A845C09", AssetId = "RU000A845C09",
                    BondType = BondType.Corporate,
                });
                context.Bonds.Add(new Bond
                {
                    Id = 5, CurrencyId = 2, ExchangeId = 1, IssuerId = 5, LotSize = 10,
                    StartPeriod = DateTime.Parse("9/29/2018"), Name = "Alrosa 001P-AR15", Isin = "RU000A651C89", Ticker = "RU000A651C89", AssetId = "RU000A651C89",
                    BondType = BondType.Corporate,
                });
                context.Bonds.Add(new Bond
                {
                    Id = 6, CurrencyId = 1, ExchangeId = 1, IssuerId = 6, LotSize = 10,
                    StartPeriod = DateTime.Parse("9/29/2018"), Name = "Apple 064", Isin = "USA000A553C00", Ticker = "USA000A553C00", AssetId = "USA000A553C00",
                    BondType = BondType.Corporate,
                });
            }
            
            if (!context.Stocks.Any())
            {
                context.Stocks.Add(new Stock
                {
                    Id = 1, CurrencyId = 2, ExchangeId = 1, IssuerId = 2, LotSize = 10,
                    StartPeriod = DateTime.Parse("9/29/2018"), Name = "Sberbank, regular stock", Isin = "RU0009029540", Ticker = "RU0009029540", AssetId = "SBER",
                    StockType = StockType.Regular,
                });
                context.Stocks.Add(new Stock
                {
                    Id = 2, CurrencyId = 2, ExchangeId = 1, IssuerId = 2, LotSize = 10,
                    StartPeriod = DateTime.Parse("9/29/2018"), Name = "Sberbank, vip stock", Isin = "RU0009029557", Ticker = "RU0009029557", AssetId = "SBERP",
                    StockType = StockType.Vip,
                });
                context.Stocks.Add(new Stock
                {
                    Id = 3, CurrencyId = 2, ExchangeId = 1, IssuerId = 1, LotSize = 10,
                    StartPeriod = DateTime.Parse("9/29/2018"), Name = "Yadex, regular stock", Isin = "RU0009029555", Ticker = "RU000902955", AssetId = "YAND",
                    StockType = StockType.Regular,
                });
                context.Stocks.Add(new Stock
                {
                    Id = 4, CurrencyId = 2, ExchangeId = 1, IssuerId = 1, LotSize = 10,
                    StartPeriod = DateTime.Parse("9/29/2018"), Name = "Yadex, vip stock", Isin = "RU0009025566", Ticker = "RU0009025566", AssetId = "YANDP",
                    StockType = StockType.Vip,
                });
                context.Stocks.Add(new Stock
                {
                    Id = 5, CurrencyId = 2, ExchangeId = 1, IssuerId = 3, LotSize = 10,
                    StartPeriod = DateTime.Parse("9/29/2018"), Name = "MTC, regular stock", Isin = "RU0009055741", Ticker = "RU0009055741", AssetId = "RU000A551C22",
                    StockType = StockType.Regular,
                });
                context.Stocks.Add(new Stock
                {
                    Id = 6, CurrencyId = 2, ExchangeId = 1, IssuerId = 4, LotSize = 10,
                    StartPeriod = DateTime.Parse("9/29/2018"), Name = "SG, regular stock", Isin = "RU0009066566", Ticker = "RU0009066566", AssetId = "RU000A845C09",
                    StockType = StockType.Regular,
                });
                context.Stocks.Add(new Stock
                {
                    Id = 7, CurrencyId = 2, ExchangeId = 1, IssuerId = 5, LotSize = 10,
                    StartPeriod = DateTime.Parse("9/29/2018"), Name = "Alrosa, regular stock", Isin = "RU0009044566", Ticker = "RU0009044566", AssetId = "RU000A651C89",
                    StockType = StockType.Regular,
                });
                context.Stocks.Add(new Stock
                {
                    Id = 8, CurrencyId = 1, ExchangeId = 1, IssuerId = 6, LotSize = 10,
                    StartPeriod = DateTime.Parse("9/29/2018"), Name = "Apple, regular stock", Isin = "USA0009025266", Ticker = "USA0009025266", AssetId = "USA000A553C00",
                    StockType = StockType.Regular,
                });

                await context.SaveChangesAsync();
            }
        }
    }
}