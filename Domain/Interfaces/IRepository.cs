using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntitade
    {
        Task<T> InsereAsync(T item);
        Task<T> AtualizaAsync(T item);
        Task<bool> ExcluiAsync(int id);
        Task<T> BuscaAsync(int id);
        Task<IEnumerable<T>> BuscaAsync();
        Task<bool> ExisteAsync(int id);
    }
}
