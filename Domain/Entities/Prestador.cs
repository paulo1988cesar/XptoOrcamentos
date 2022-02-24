using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Prestador : BaseEntitade
    {
        [Required]
        [MaxLength(150)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(11)]
        public string CPF { get; set; }

        [ForeignKey(nameof(Empresa))]
        public int IdEmpresa { get; set; }
        public virtual Empresa Empresa { get; set; }
    }
}
