using Data;
using Data.Context;
using Data.Implementations;
using Domain.Interfaces;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infra
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection servicesCollections)
        {
            servicesCollections.AddDbContext<MyContext>(
                opt => opt.UseSqlServer(Appsettings.DefaultConnection)
            );
            servicesCollections.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            servicesCollections.AddScoped<IOrdemServicoRepository, OrdemServicoImplementation>();
            servicesCollections.AddScoped<ILogServiceRepository, LogFalhaImplementation>();
        }
    }
}
