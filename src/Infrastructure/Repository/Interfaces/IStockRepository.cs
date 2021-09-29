using System.Collections.Generic;
using System.Threading.Tasks;
using InvestExplorer.Domain.Entities;

namespace InvestExplorer.Infrastructure.Repository.Interfaces
{
    public interface IStockRepository
    {
        public Task<Stock> GetById(string id);
        public Task<Stock> GetByIsin(string isin);
        public Task<List<Stock>> FindByName(string name);
        public Task<List<Stock>> FindByIsin(string isin);
        public Task<List<Stock>> FindByTicker(string ticker);
        public Task<List<Stock>> GetByIssuerId(int issuerId);
        
        public Task<List<Stock>> GetAvailableByIssuerId(int issuerId);
    }
}