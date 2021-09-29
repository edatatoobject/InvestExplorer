using InvestExplorer.Domain.Entities;
using InvestExplorer.Infrastructure.Persistence;
using InvestExplorer.Infrastructure.Repository.Interfaces;

namespace InvestExplorer.Infrastructure.Repository
{
    public class BondRepository : BaseAssetRepository<Bond>, IBondRepository
    {
        public BondRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}