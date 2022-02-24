using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IEmpresaService
    {
        Task<Empresa> Buscar(int id);
        Task<IEnumerable<Empresa>> Buscar();
        Task<bool> Inserir(Empresa empresa);
        Task<bool> Atualizar(Empresa empresa);
        Task<bool> Excluir(int id);
    }
}
