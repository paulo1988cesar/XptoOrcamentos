using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IOrdemServicoService
    {
        Task<OrdemServico> Buscar(int id);
        Task<IEnumerable<OrdemServico>> Buscar();
        Task<bool> Inserir(OrdemServico ordem);
        Task<bool> Atualizar(OrdemServico ordem);
        Task<bool> Excluir(int id);
    }
}
