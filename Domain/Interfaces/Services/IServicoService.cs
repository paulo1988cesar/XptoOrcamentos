using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IServicoService
    {
        Task<Servico> Buscar(int id);
        Task<IEnumerable<Servico>> Buscar();
        Task<bool> Inserir(Servico servico);
        Task<bool> Atualizar(Servico servico);
        Task<bool> Excluir(int id);
    }
}
