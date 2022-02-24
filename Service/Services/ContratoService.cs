using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Services
{
    public class ContratoService : IContratoService
    {
        private readonly IRepository<Contrato> _repo;

        public ContratoService(IRepository<Contrato> repo)
        {
            _repo = repo;
        }

        public async Task<bool> Excluir(int id)
        {
            return await _repo.ExcluiAsync(id);
        }

        public async Task<Contrato> Buscar(int id)
        {
            return await _repo.BuscaAsync(id);
        }

        public async Task<IEnumerable<Contrato>> Buscar()
        {
            return await _repo.BuscaAsync();
        }

        public async Task<bool> Inserir(Contrato contrato)
        {
            try
            {
                await _repo.InsereAsync(contrato);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Atualizar(Contrato contrato)
        {
            try
            {
                await _repo.AtualizaAsync(contrato);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}