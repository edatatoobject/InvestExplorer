using System;
using InvestExplorer.Domain.Common;
using InvestExplorer.Domain.Entities.Dictionary;

namespace InvestExplorer.Domain.Entities
{
    public abstract class BaseAsset : BaseEntity
    {
        public string AssetId { get; set; }
        public string Name { get; set; }
        public string Ticker { get; set; }
        public string Isin { get; set; }
        public int LotSize { get; set; }
        public int IssuerId { get; set; }
        public Issuer Issuer { get; set; }
        public int ExchangeId { get; set; }
        public Exchange Exchange { get; set; }
        public int CurrencyId { get; set; }
        public Currency Currency { get; set; }
        public DateTime StartPeriod { get; set; }
        public DateTime? StopPeriod { get; set; }
    }
}