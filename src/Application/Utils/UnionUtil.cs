using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using InvestExplorer.Application.Dto;
using InvestExplorer.Domain.Entities;

namespace InvestExplorer.Application.Utils
{
    public class UnionUtil
    {
        private readonly IMapper _mapper;

        public UnionUtil(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<AssetDto> UnionAssets(List<Stock> stocks, List<Bond> bonds)
        {
            var stocksDto = _mapper.Map<List<Stock>, List<AssetDto>>(stocks);
            var bondsDto = _mapper.Map<List<Bond>, List<AssetDto>>(bonds);
            return stocksDto.Union(bondsDto).ToList();
        }
    }
}