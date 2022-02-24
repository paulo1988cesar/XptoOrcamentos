using Data.Context;
using Domain.Entities;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Implementations
{
    public class OrdemServicoImplementation : BaseRepository<OrdemServico>, IOrdemServicoRepository
    {
        private readonly MyContext _myContext;

        public OrdemServicoImplementation(MyContext context) : base(context)
        {
            _myContext = context;
        }
        public async Task<IEnumerable<OrdemServico>> BuscarOrdem()
        {
            return await _myContext.OrdemServico
                                   .Include(c => c.Contrato)
                                   .Include(c => c.Servico).ToListAsync();
        }

        public async Task<OrdemServico> BuscarOrdem(int id)
        {
            return await _myContext.OrdemServico
                                   .Include(c => c.Contrato)
                                   .Include(c => c.Servico).FirstOrDefaultAsync(c => c.Id.Equals(id));
        }
    }
}
