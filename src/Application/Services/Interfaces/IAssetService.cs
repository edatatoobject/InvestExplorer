using System.Collections.Generic;
using System.Threading.Tasks;
using InvestExplorer.Application.Dto;
using InvestExplorer.Application.QueryParameters;

namespace InvestExplorer.Application.Services.Interfaces
{
    public interface IAssetService
    {
        public Task<AssetDto> Get(string id);
        public Task<AssetDto> GetByIsin(string isin);
        public Task<List<AssetDto>> GetByParameters(AssetQueryParameter queryParameter);
    }
}