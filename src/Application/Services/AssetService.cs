using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using InvestExplorer.Application.Dto;
using InvestExplorer.Application.Enum;
using InvestExplorer.Application.QueryParameters;
using InvestExplorer.Application.Services.Interfaces;
using InvestExplorer.Application.Utils;
using InvestExplorer.Domain.Entities;
using InvestExplorer.Infrastructure.Repository.Interfaces;

namespace InvestExplorer.Application.Services
{
    public class AssetService : IAssetService
    {
        private readonly IStockRepository _stockRepository;
        private readonly IBondRepository _bondRepository;
        private readonly IMapper _mapper;
        private readonly UnionUtil _unionUtil;

        public AssetService(IStockRepository stockRepository, IBondRepository bondRepository, IMapper mapper)
        {
            _stockRepository = stockRepository;
            _bondRepository = bondRepository;
            _mapper = mapper;
            _unionUtil = new UnionUtil(mapper);
        }

        public async Task<AssetDto> Get(string id)
        {
            var stock = await _stockRepository.GetById(id);

            if (stock != null)
                return _mapper.Map<AssetDto>(stock);

            var bond = await _bondRepository.GetById(id);

            if (bond != null)
                return _mapper.Map<AssetDto>(bond);

            return null;
        }

        public async Task<AssetDto> GetByIsin(string isin)
        {
            var stock = await _stockRepository.GetByIsin(isin);

            if (stock != null)
                return _mapper.Map<AssetDto>(stock);

            var bond = await _bondRepository.GetByIsin(isin);

            if (bond != null)
                return _mapper.Map<AssetDto>(bond);

            return null;
        }

        public async Task<List<AssetDto>> GetByParameters(AssetQueryParameter queryParameter)
        {
            List<AssetDto> result = new List<AssetDto>();

            if (!string.IsNullOrEmpty(queryParameter.Name))
            {
                result = await FindBy(queryParameter, value => _stockRepository.FindByName(value),
                    value => _bondRepository.FindByName(value), queryParameter.Name);
            }
            else if (!string.IsNullOrEmpty(queryParameter.Ticker))
            {
                result = await FindBy(queryParameter, async value => await _stockRepository.FindByTicker(value),
                    async value => await _bondRepository.FindByTicker(value), queryParameter.Ticker);
            }
            else
            {
                result = await FindBy(queryParameter, value => _stockRepository.FindByIsin(value),
                    value => _bondRepository.FindByIsin(value), queryParameter.Isin);
            }

            return result;
        }

        private async Task<List<AssetDto>> FindBy(AssetQueryParameter queryParameter,
            Func<string, Task<List<Stock>>> stockGetFunction, Func<string, Task<List<Bond>>> bondGetFunction,
            string value)
        {
            if (queryParameter.AssetType != AssetTypeEnum.None)
            {
                if (queryParameter.AssetType == AssetTypeEnum.Stock)
                {
                    return _mapper.Map<List<Stock>, List<AssetDto>>(await stockGetFunction(value));
                }
                else
                {
                    return _mapper.Map<List<Bond>, List<AssetDto>>(await bondGetFunction(value));
                }
            }

            return _unionUtil.UnionAssets(await stockGetFunction(value), await bondGetFunction(value));
        }

        
    }
}