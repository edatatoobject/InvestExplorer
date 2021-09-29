using System.Text.Json.Serialization;

namespace InvestExplorer.Application.Dto.Dictionary
{
    public class ExchangeDto
    {
        [JsonPropertyName("code")] public string Code { get; set; }
        [JsonPropertyName("name")] public string Name { get; set; }
    }
}