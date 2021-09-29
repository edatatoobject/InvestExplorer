using System.Text.Json.Serialization;

namespace InvestExplorer.Application.Dto.Dictionary
{
    public class IssuerDto
    {
        
        [JsonPropertyName("id")] public int Id { get; set; }
        [JsonPropertyName("name")] public string Name { get; set; }
        [JsonPropertyName("country")] public string Country { get; set; }
        [JsonPropertyName("industry")] public string Industry { get; set; }
    }
}