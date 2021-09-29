using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvestExplorer.Domain.Entities;
using InvestExplorer.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace InvestExplorer.Infrastructure.Repository
{
    public abstract class BaseAssetRepository<T> : BaseRepository<T> where T : BaseAsset
    {
        public BaseAssetRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<T> GetById(string id)
        {
            return await _dbSet.Include(e => e.Currency).Include(e => e.Exchange).Include(e => e.Issuer)
                .FirstOrDefaultAsync(e => e.AssetId == id);
        }

        public async Task<T> GetByIsin(string isin)
        {
            return await _dbSet.Include(e => e.Currency).Include(e => e.Exchange).Include(e => e.Issuer)
                .FirstOrDefaultAsync(e => e.Isin == isin);
        }

        public async Task<List<T>> FindByName(string name)
        {
            return await _dbSet.Include(e => e.Currency).Include(e => e.Exchange).Include(e => e.Issuer)
                .Where(e => e.Name.Contains(name)).ToListAsync();
        }

        public async Task<List<T>> FindByIsin(string isin)
        {
            return await _dbSet.Include(e => e.Currency).Include(e => e.Exchange).Include(e => e.Issuer)
                .Where(e => e.Isin.Contains(isin)).ToListAsync();
        }

        public async Task<List<T>> FindByTicker(string ticker)
        {
            return await _dbSet.Include(e => e.Currency).Include(e => e.Exchange).Include(e => e.Issuer)
                .Where(e => e.Ticker.Contains(ticker)).ToListAsync();
        }

        public async Task<List<T>> GetByIssuerId(int issuerId)
        {
            return await _dbSet.Include(e => e.Currency).Include(e => e.Exchange).Include(e => e.Issuer)
                .Where(e => e.IssuerId == issuerId).ToListAsync();
        }

        public async Task<List<T>> GetAvailableByIssuerId(int issuerId)
        {
            return await _dbSet.Include(e => e.Currency).Include(e => e.Exchange).Include(e => e.Issuer)
                .Where(e => e.IssuerId == issuerId && e.StopPeriod != null).ToListAsync();
        }
    }
}