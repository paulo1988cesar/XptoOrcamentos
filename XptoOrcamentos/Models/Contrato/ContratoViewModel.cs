using System.Collections.Generic;

namespace XptoOrcamentos.Models.Contrato
{
    public class ContratoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public List<ContratoCliente> Contratos { get; set; }
    }

    public class ContratoCliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public string Cidade { get; set; }
    }
}
