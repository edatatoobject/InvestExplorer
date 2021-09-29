using System.Collections.Generic;
using System.Threading.Tasks;
using InvestExplorer.Domain.Entities.Dictionary;
using InvestExplorer.Infrastructure.Persistence;
using InvestExplorer.Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InvestExplorer.Infrastructure.Repository
{
    public class IssuerRepository : BaseRepository<Issuer>, IIssuerRepository
    {
        public IssuerRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<List<Issuer>> GetAllAsync()
        {
            return await _dbSet.Include(e => e.Country).Include(e => e.Industry).ToListAsync();
        }
    }
}