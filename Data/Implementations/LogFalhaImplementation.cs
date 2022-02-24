using Data.Context;
using Domain.Entities;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implementations
{
    public class LogFalhaImplementation : ILogServiceRepository
    {
        private readonly MyContext _myContext;

        public LogFalhaImplementation(MyContext context)
        {
            _myContext = context;
        }
        public async Task<bool> InserirLog(LogFalhas log)
        {
            try
            {
                _myContext.LogFalhas.Add(log);
                await _myContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }
    }
}
