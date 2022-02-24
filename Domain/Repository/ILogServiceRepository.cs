using Domain.Entities;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface ILogServiceRepository 
    {
        Task<bool> InserirLog(LogFalhas log);
    }
}
