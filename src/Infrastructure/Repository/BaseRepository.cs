using System.Collections.Generic;
using System.Threading.Tasks;
using InvestExplorer.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace InvestExplorer.Infrastructure.Repository
{
    public abstract class BaseRepository<T> where T : class
    {
        private ApplicationDbContext _context;
        protected DbSet<T> _dbSet;

        protected BaseRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<T> GetAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
    }
}