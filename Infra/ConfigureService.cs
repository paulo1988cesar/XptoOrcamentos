using Domain.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;
using Service.Services;

namespace Infra
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection servicesCollections)
        {
            servicesCollections.AddTransient<IServicoService, ServicoService>();
            servicesCollections.AddTransient<IPrestadorService, PrestadorService>();
            servicesCollections.AddTransient<IContratoService, ContratoService>();
            servicesCollections.AddTransient<IOrdemServicoService, OrdemServicoService>();
            servicesCollections.AddTransient<IEmpresaService, EmpresaService>();
        }
    }
}
