using Domain.Entities;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface IOrdemServicoRepository : IRepository<OrdemServico>
    {
        Task<IEnumerable<OrdemServico>> BuscarOrdem();
        Task<OrdemServico> BuscarOrdem(int id);
    }
}
