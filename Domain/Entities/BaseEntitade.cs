using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class BaseEntitade
    {
        [Key]
        public int Id { get; set; }

        private DateTime? _criadoEm;

        public DateTime? CriadoEm
        {
            get { return _criadoEm; }
            set { _criadoEm = (value == null ? DateTime.UtcNow : value) ; }
        }

        public DateTime? AtualizadoEm { get; set; }
    }
}
