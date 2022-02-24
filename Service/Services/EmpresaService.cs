using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Services
{
    public class EmpresaService : IEmpresaService
    {
        private readonly IRepository<Empresa> _repo;

        public EmpresaService(IRepository<Empresa> repo)
        {
            _repo = repo;
        }

        public async Task<bool> Excluir(int id)
        {
            return await _repo.ExcluiAsync(id);
        }

        public async Task<Empresa> Buscar(int id)
        {
            return await _repo.BuscaAsync(id);
        }

        public async Task<IEnumerable<Empresa>> Buscar()
        {
            return await _repo.BuscaAsync();
        }

        public async Task<bool> Inserir(Empresa empresa)
        {
            try
            {
                await _repo.InsereAsync(empresa);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Atualizar(Empresa empresa)
        {
            try
            {
                await _repo.AtualizaAsync(empresa);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
