using System.ComponentModel.DataAnnotations;

namespace XptoOrcamentos.Models.Servico
{
    public class ServicoViewModelNew
    {
        [Required(ErrorMessage = "O Nome do serviço é obrigatório")]
        [StringLength(100, ErrorMessage = "A quantide de máxima caracteres é de {1}")]
        public string Nome { get; set; }
    }
}
