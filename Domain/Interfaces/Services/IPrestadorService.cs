using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IPrestadorService
    {
        Task<Prestador> Buscar(int id);
        Task<IEnumerable<Prestador>> Buscar();
        Task<bool> Inserir(Prestador prestador);
        Task<bool> Atualizar(Prestador prestador);
        Task<bool> Excluir(int id);
    }
}
