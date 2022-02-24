using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Services
{
    public class OrdemServicoService : IOrdemServicoService
    {
        private readonly IRepository<OrdemServico> _repo;

        public OrdemServicoService(IRepository<OrdemServico> repo)
        {
            _repo = repo;
        }

        public async Task<bool> Excluir(int id)
        {
            return await _repo.ExcluiAsync(id);
        }

        public async Task<OrdemServico> Buscar(int id)
        {
            return await _repo.BuscaAsync(id);
        }

        public async Task<IEnumerable<OrdemServico>> Buscar()
        {
            return await _repo.BuscaAsync();
        }

        public async Task<bool> Inserir(OrdemServico ordem)
        {
            try
            {
                await _repo.InsereAsync(ordem);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Atualizar(OrdemServico ordem)
        {
            try
            {
                await _repo.AtualizaAsync(ordem);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
