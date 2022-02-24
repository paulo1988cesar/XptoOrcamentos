using System.Collections.Generic;

namespace XptoOrcamentos.Models.Prestador
{
    public class PrestadorViewModel
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public List<Prestadores> Prestadores { get; set; }
    }

    public class Prestadores
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
    }
}
