using System.Text.Json.Serialization;

namespace InvestExplorer.Application.Dto
{
    public abstract class BaseAssetDto
    {
        [JsonPropertyName("id")] public string AssetId { get; set; }
        [JsonPropertyName("name")] public string Name { get; set; }
        [JsonPropertyName("class")] public string AssetClass { get; set; }
        [JsonPropertyName("type")] public string AssetType { get; set; }
        [JsonPropertyName("ticker")] public string Ticker { get; set; }
        [JsonPropertyName("isis")] public string Isin { get; set; }
    }
}