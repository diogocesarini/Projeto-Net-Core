using Microsoft.Extensions.DependencyInjection;
using ProjetoEnngie.Business.Interfaces;
using ProjetoEnngie.Business.Services;
using ProjetoEnngie.Data.Context;
using ProjetoEnngie.Data.Repository;

namespace ProjetoEnngie.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<MeuDBContext>();
            services.AddScoped<IFornecedorRepository, FornecedorRepository>();
            services.AddScoped<IFornecedorService, FornecedorService>();
            services.AddScoped<IUsinaService, UsinaService>();
            services.AddScoped<IUsinaRepository, UsinaRepository>();

            return services;
        }
    }
}