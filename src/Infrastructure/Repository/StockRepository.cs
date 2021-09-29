using InvestExplorer.Domain.Entities;
using InvestExplorer.Infrastructure.Persistence;
using InvestExplorer.Infrastructure.Repository.Interfaces;

namespace InvestExplorer.Infrastructure.Repository
{
    public class StockRepository : BaseAssetRepository<Stock>, IStockRepository
    {
        public StockRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}