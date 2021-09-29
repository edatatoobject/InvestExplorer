using System.Collections.Generic;
using System.Threading.Tasks;
using InvestExplorer.Domain.Entities.Dictionary;

namespace InvestExplorer.Infrastructure.Repository.Interfaces
{
    public interface IIssuerRepository
    {
        public Task<List<Issuer>> GetAllAsync();
    }
}