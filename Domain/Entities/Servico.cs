using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Servico")]
    public class Servico : BaseEntitade
    {
        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }
        
    }
}
