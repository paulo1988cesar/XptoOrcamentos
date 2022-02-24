using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Contrato : BaseEntitade
    {
        [Required]
        [MaxLength(150)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(14)]
        public string CNPJ { get; set; }

        [Required]
        [MaxLength(150)]
        public string Logradouro { get; set; }

        [Required]
        [MaxLength(50)]
        public string Bairro { get; set; }

        [Required]
        [MaxLength(50)]
        public string Complemento { get; set; }

        [Required]
        [MaxLength(50)]
        public string Cidade { get; set; }

        [Required]
        [MaxLength(50)]
        public string Estado { get; set; }

        [Required]
        [MaxLength(8)]
        public string CEP { get; set; }
    }
}
