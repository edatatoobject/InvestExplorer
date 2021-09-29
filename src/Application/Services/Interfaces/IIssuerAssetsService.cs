using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InvestExplorer.Application.Dto;
using InvestExplorer.Application.Dto.Dictionary;
using InvestExplorer.Application.QueryParameters;

namespace InvestExplorer.Application.Services.Interfaces
{
    public interface IIssuerAssetsService
    {
        public Task<List<AssetDto>> GetAssets(IssuerAssetQueryParameters queryParameters);
    }
}