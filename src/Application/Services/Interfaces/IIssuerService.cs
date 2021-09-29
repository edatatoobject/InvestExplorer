using System.Collections.Generic;
using System.Threading.Tasks;
using InvestExplorer.Application.Dto;
using InvestExplorer.Application.Dto.Dictionary;

namespace InvestExplorer.Application.Services.Interfaces
{
    public interface IIssuerService
    {
        public Task<List<IssuerDto>> GetAll();
    }
}