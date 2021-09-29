using AutoMapper;
using InvestExplorer.Application.Dto;
using InvestExplorer.Application.Dto.Dictionary;
using InvestExplorer.Domain.Common;
using InvestExplorer.Domain.Entities;
using InvestExplorer.Domain.Entities.Dictionary;

namespace InvestExplorer.Application.Automapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Bond, AssetDto>()
                .BeforeMap((s, d) => d.AssetClass = AssetClass.Bond)
                .ForMember(d => d.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(d => d.Currency, opt => opt.MapFrom(src => src.Currency.Code))
                .ForMember(d => d.AssetType, opt => opt.MapFrom(src => src.BondType.ToString()));
            CreateMap<Stock, AssetDto>()
                .BeforeMap((s, d) => d.AssetClass = AssetClass.Stock)
                .ForMember(d => d.Currency, opt => opt.MapFrom(src => src.Currency.Code))
                .ForMember(d => d.AssetType, opt => opt.MapFrom(src => src.StockType.ToString()));


            CreateMap<AssetDto, ShortAssetInfoDto>()
                .ForMember(d => d.ExchangeCode, opt => opt.MapFrom(src => src.Exchange.Name))
                .ForMember(d => d.IssuerName, opt => opt.MapFrom(src => src.Issuer.Name));
            CreateMap<AssetDto, ShortAssetInfoDto>()
                .ForMember(d => d.ExchangeCode, opt => opt.MapFrom(src => src.Exchange.Name))
                .ForMember(d => d.IssuerName, opt => opt.MapFrom(src => src.Issuer.Name));

            CreateMap<Issuer, IssuerDto>()
                .ForMember(d => d.Country, opt => opt.MapFrom(src => src.Country.Name))
                .ForMember(d => d.Industry, opt => opt.MapFrom(src => src.Industry.Symbol));
            CreateMap<Exchange, ExchangeDto>();
        }
    }
}