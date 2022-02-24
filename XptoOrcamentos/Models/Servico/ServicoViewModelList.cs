using System.Collections.Generic;

namespace XptoOrcamentos.Models
{
    public class ServicoViewModelList
    {
        public List<Servicos> Servicos { get; set; }
    }

    public class Servicos
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
