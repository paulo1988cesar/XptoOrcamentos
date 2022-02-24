using System;

namespace Domain.Models
{
    public class BaseModel
    {
        private DateTime _criadoEm;

        public DateTime CriadoEm
        {
            get { return _criadoEm; }
            set
            {
                _criadoEm = value == null ? DateTime.UtcNow : value;
            }
        }

        private DateTime _atualizadoEm;

        public DateTime AtualizadoEm
        {
            get { return _atualizadoEm; }
            set { _atualizadoEm = value; }
        }
    }
}
