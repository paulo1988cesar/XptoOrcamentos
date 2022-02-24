using System.ComponentModel.DataAnnotations;

namespace XptoOrcamentos.Models.Contrato
{
    public class ContratoViewModelNew
    {
        [Required(ErrorMessage = "O Nome do Cliente é obrigatório.")]
        [StringLength(150)]
        public string Nome { get; set; }
        
        [Required(ErrorMessage ="O CNPJ é obrigatório")]
        [StringLength(14)]
        public string CNPJ { get; set; }
        
        [Required(ErrorMessage ="O Logradouro é obrigatório")]
        [StringLength(150)]
        public string Logradouro { get; set; }
        
        [Required(ErrorMessage = "O Bairro é obrigatório")]
        [StringLength(50)]
        public string Bairro { get; set; }
        
        [Required(ErrorMessage = "O Complemento é obrigatório")]
        [StringLength(50)]
        public string Complemento { get; set; }
        
        [Required(ErrorMessage = "A Cidade é obrigatório")]
        [StringLength(50)]
        public string Cidade { get; set; }

        [Required(ErrorMessage ="O Estado é obrigatório")]
        [StringLength(50)]
        public string Estado { get; set; }
        
        [Required(ErrorMessage ="O CEP é obrigatório")]
        [StringLength(8)]
        public string CEP { get; set; }
    }
}
