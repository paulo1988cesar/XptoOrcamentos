using System.Collections.Generic;

namespace XptoOrcamentos.Models.Empresa
{
    public class EmpreaViewModel
    {
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public List<Empresas> Empresas { get; set; }
    }

    public class Empresas
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }
    }
}
