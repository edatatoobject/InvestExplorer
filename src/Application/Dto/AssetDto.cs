using System;
using System.Text.Json.Serialization;
using InvestExplorer.Application.Dto.Dictionary;

namespace InvestExplorer.Application.Dto
{
    public class AssetDto : BaseAssetDto
    {
        [JsonPropertyName("lotSize")] public int LotSize { get; set; }
        [JsonPropertyName("issuer")] public IssuerDto Issuer { get; set; }
        [JsonPropertyName("exchange")] public ExchangeDto Exchange { get; set; }
        [JsonPropertyName("currency")] public string Currency { get; set; }
        [JsonPropertyName("startPeriod")] public DateTime StartPeriod { get; set; }
        [JsonPropertyName("stopPeriod")] public DateTime? StopPeriod { get; set; }
    }
}