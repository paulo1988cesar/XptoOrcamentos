using System.ComponentModel.DataAnnotations;

namespace XptoOrcamentos.Models.Empresa
{
    public class EmpreaViewModelNew
    {
        [Required(ErrorMessage = "O Nome é obrigatório")]
        [StringLength(150)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O CNPJ é obrigatório")]
        [StringLength(14)]
        public string CNPJ { get; set; }
    }
}
