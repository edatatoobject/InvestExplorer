using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using InvestExplorer.Application.Dto;
using InvestExplorer.Application.QueryParameters;
using InvestExplorer.Application.Services.Interfaces;
using InvestExplorer.Application.Utils;
using InvestExplorer.Infrastructure.Repository.Interfaces;

namespace InvestExplorer.Application.Services
{
    public class IssuerAssetsService : IIssuerAssetsService
    {
        private readonly IStockRepository _stockRepository;
        private readonly IBondRepository _bondRepository;
        private readonly UnionUtil _unionUtil;

        public IssuerAssetsService(IStockRepository stockRepository, IBondRepository bondRepository, IMapper mapper)
        {
            _stockRepository = stockRepository;
            _bondRepository = bondRepository;
            _unionUtil = new UnionUtil(mapper);
        }

        public async Task<List<AssetDto>> GetAssets(IssuerAssetQueryParameters queryParameters)
        {
            List<AssetDto> result;
            
            if (queryParameters.Available)
            {
                result = _unionUtil.UnionAssets(await _stockRepository.GetAvailableByIssuerId(queryParameters.IssuerId),
                    await _bondRepository.GetAvailableByIssuerId(queryParameters.IssuerId));
            }
            else
            {
                result = _unionUtil.UnionAssets(await _stockRepository.GetByIssuerId(queryParameters.IssuerId),
                    await _bondRepository.GetByIssuerId(queryParameters.IssuerId));
            }

            if (queryParameters.Sort)
            {
                result.Sort((x,y) => x.StartPeriod.CompareTo(y.StartPeriod));
            }
            
            return result;
        }
    }
}