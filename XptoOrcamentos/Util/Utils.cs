using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XptoOrcamentos.Util
{
    public class Utils
    {
        public static LogFalhas RetornaObjetoErro(Exception ex)
        {
            return new LogFalhas
            {
                DataHoraFalha = DateTime.Now,
                Exception = ex.Message,
                StackTrace = ex.StackTrace
            };
        }
    }
}
