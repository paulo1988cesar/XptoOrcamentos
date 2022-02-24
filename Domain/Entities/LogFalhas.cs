using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class LogFalhas
    {

        [Key]
        public int Id { get; set; }

        [MaxLength(2500)]
        public string Exception { get; set; }

        [MaxLength(2500)]
        public string StackTrace { get; set; }

        public DateTime DataHoraFalha { get; set; }
    }
}
