using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    public class OrdemServico : BaseEntitade
    {
        public string NumeroOS { get; set; }

        [ForeignKey(nameof(Contrato))]
        public int IdContrato { get; set; }
        public virtual Contrato Contrato { get; set; }

        [ForeignKey(nameof(Servico))]
        public int IdServico { get; set; }
        public virtual Servico Servico { get; set; }

        [ForeignKey(nameof(Prestador))]
        public int IdPrestador { get; set; }
        public virtual Prestador Prestador { get; set; }
        
        public DateTime DataAbertura { get; set; }
        public DateTime DateExecucao { get; set; }
        public decimal ValorServico { get; set; }
    }
}
