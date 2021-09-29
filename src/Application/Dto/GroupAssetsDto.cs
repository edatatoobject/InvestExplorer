using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace InvestExplorer.Application.Dto
{
    public class GroupAssetsDto<T> where T : class
    {
        [JsonPropertyName("stocks")] public List<T> StockParameters { get; set; }
        [JsonPropertyName("bonds")] public List<T> BondParameters { get; set; }

        public GroupAssetsDto(List<T> stockParameters, List<T> bondParameters)
        {
            StockParameters = stockParameters;
            BondParameters = bondParameters;
        }
    }
}