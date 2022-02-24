using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IContratoService
    {
        Task<Contrato> Buscar(int id);
        Task<IEnumerable<Contrato>> Buscar();
        Task<bool> Inserir(Contrato contrato);
        Task<bool> Atualizar(Contrato contrato);
        Task<bool> Excluir(int id);
    }
}
