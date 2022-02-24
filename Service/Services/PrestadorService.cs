using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Services
{
    public class PrestadorService : IPrestadorService
    {
        private readonly IRepository<Prestador> _repo;

        public PrestadorService(IRepository<Prestador> repo)
        {
            _repo = repo;
        }

        public async Task<bool> Excluir(int id)
        {
            return await _repo.ExcluiAsync(id);
        }

        public async Task<Prestador> Buscar(int id)
        {
            return await _repo.BuscaAsync(id);
        }

        public async Task<IEnumerable<Prestador>> Buscar()
        {
            return await _repo.BuscaAsync();
        }

        public async Task<bool> Inserir(Prestador prestador)
        {
            try
            {
                await _repo.InsereAsync(prestador);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Atualizar(Prestador prestador)
        {
            try
            {
                await _repo.AtualizaAsync(prestador);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
