using InvestExplorer.Infrastructure.Persistence;
using InvestExplorer.Infrastructure.Repository;
using InvestExplorer.Infrastructure.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InvestExplorer.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(
                    configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<IBondRepository, BondRepository>();
            services.AddTransient<IStockRepository, StockRepository>();
            services.AddTransient<IIssuerRepository, IssuerRepository>();

            return services;
        }
    }
}