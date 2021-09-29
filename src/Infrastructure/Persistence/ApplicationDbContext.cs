using InvestExplorer.Domain.Entities;
using InvestExplorer.Domain.Entities.Dictionary;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InvestExplorer.Infrastructure.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int,
        IdentityUserClaim<int>, IdentityUserRole<int>, IdentityUserLogin<int>, IdentityRoleClaim<int>,
        IdentityUserToken<int>>
    {
        public DbSet<Bond> Bonds { get; set; }
        public DbSet<Stock> Stocks { get; set; }


        public DbSet<Country> Countries { get; set; }

        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Exchange> Exchanges { get; set; }
        public DbSet<Industry> Industries { get; set; }
        public DbSet<Issuer> Issuers { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}