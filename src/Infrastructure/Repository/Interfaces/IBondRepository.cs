using System.Collections.Generic;
using System.Threading.Tasks;
using InvestExplorer.Domain.Entities;

namespace InvestExplorer.Infrastructure.Repository.Interfaces
{
    public interface IBondRepository
    {
        public Task<Bond> GetById(string id);
        public Task<Bond> GetByIsin(string isin);
        public Task<List<Bond>> FindByName(string name);
        public Task<List<Bond>> FindByIsin(string isin);
        public Task<List<Bond>> FindByTicker(string ticker);

        public Task<List<Bond>> GetByIssuerId(int issuerId);
        
        public Task<List<Bond>> GetAvailableByIssuerId(int issuerId);
    }
}