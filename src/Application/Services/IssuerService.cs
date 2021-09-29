using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using InvestExplorer.Application.Dto;
using InvestExplorer.Application.Dto.Dictionary;
using InvestExplorer.Application.Services.Interfaces;
using InvestExplorer.Domain.Entities.Dictionary;
using InvestExplorer.Infrastructure.Repository.Interfaces;

namespace InvestExplorer.Application.Services
{
    public class IssuerService : IIssuerService
    {
        private readonly IIssuerRepository _issuerRepository;
        private readonly IMapper _mapper;

        public IssuerService(IIssuerRepository issuerRepository, IMapper mapper)
        {
            _issuerRepository = issuerRepository;
            _mapper = mapper;
        }

        public async Task<List<IssuerDto>> GetAll()
        {
            return _mapper.Map<List<Issuer>, List<IssuerDto>>(await _issuerRepository.GetAllAsync());
        }
    }
}