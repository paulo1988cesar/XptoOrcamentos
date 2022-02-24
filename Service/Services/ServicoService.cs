using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Services
{
    public class ServicoService : IServicoService
    {
        private readonly IRepository<Servico> _repo;

        public ServicoService(IRepository<Servico> repo)
        {
            _repo = repo;
        }

        public async Task<bool> Excluir(int id)
        {
            return await _repo.ExcluiAsync(id);
        }

        public async Task<Servico> Buscar(int id)
        {
            return await _repo.BuscaAsync(id);
        }

        public async Task<IEnumerable<Servico>> Buscar()
        {
            return await _repo.BuscaAsync();
        }

        public async Task<bool> Inserir(Servico servico)
        {
            try
            {
                await _repo.InsereAsync(servico);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Atualizar(Servico servico)
        {
            try
            {
                await _repo.AtualizaAsync(servico);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
