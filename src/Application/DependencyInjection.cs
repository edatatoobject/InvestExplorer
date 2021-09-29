using System.Reflection;
using AutoMapper;
using InvestExplorer.Application.Automapper;
using InvestExplorer.Application.Services;
using InvestExplorer.Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace InvestExplorer.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(e =>
            {
                e.AddProfile<AutoMapperProfile>();
                e.SourceMemberNamingConvention = new LowerUnderscoreNamingConvention();

            });

            services.AddTransient<IAssetService, AssetService>();
            services.AddTransient<IIssuerAssetsService, IssuerAssetsService>();
            services.AddTransient<IIssuerService, IssuerService>();

            return services;
        }
    }
}