using System.Text.Json.Serialization;

namespace InvestExplorer.Application.Dto.Dictionary
{
    public class ShortAssetInfoDto : BaseAssetDto
    {
        [JsonPropertyName("exchange")] public string ExchangeCode { get; set; }
        [JsonPropertyName("issuer")] public string IssuerName { get; set; }
    }
}