using System.Collections.Generic;
using AutoMapper;
using InvestExplorer.Application.Dto;
using InvestExplorer.Application.Dto.Dictionary;
using InvestExplorer.Application.QueryParameters;
using InvestExplorer.Domain.Common;
using Microsoft.AspNetCore.Mvc;

namespace InvestExplorer.WebApi.Utils
{
    public class AdditionalQueryParametersUtil
    {
        private readonly IMapper _mapper;

        public AdditionalQueryParametersUtil(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IActionResult CheckAdditionalQueryParameters(List<AssetDto> assets, BaseQueryParameter queryParameters)
        {
            if (queryParameters.ShortInfo)
            {
                var shortAssets = _mapper.Map<List<AssetDto>, List<ShortAssetInfoDto>>(assets);

                if (queryParameters.Group)
                {
                    return new OkObjectResult(new GroupAssetsDto<ShortAssetInfoDto>(
                        shortAssets.FindAll(e => e.AssetClass == AssetClass.Stock),
                        shortAssets.FindAll(e => e.AssetClass == AssetClass.Bond)));
                }

                return new OkObjectResult(shortAssets);
            }
            
            if (queryParameters.Group)
            {
                return new OkObjectResult(new GroupAssetsDto<AssetDto>(
                    assets.FindAll(e => e.AssetClass == AssetClass.Stock),
                    assets.FindAll(e => e.AssetClass == AssetClass.Bond)));
            }

            return new OkObjectResult(assets);
        }
    }
}