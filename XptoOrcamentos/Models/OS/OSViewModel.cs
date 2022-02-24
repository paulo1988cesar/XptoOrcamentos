using System;
using System.Collections.Generic;

namespace XptoOrcamentos.Models.OS
{
    public class OSViewModel
    {
        public string NroOs { get; set; }
        public string Cliente { get; set; }
        public List<Ordens> Ordens { get; set; }
    }

    public class Ordens
    {
        public int Id { get; set; }
        public string NumeroOs { get; set; }
        public string NomeCliente { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataExecucao { get; set; }
        public string Servico { get; set; }
    }
}