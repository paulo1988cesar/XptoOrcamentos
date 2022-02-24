using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace XptoOrcamentos.Models.OS
{
    public class OSViewModelEdit
    {
        public List<SelectListItem> Contrato { get; set; }
        public List<SelectListItem> Servico { get; set; }
        public List<SelectListItem> Prestador { get; set; }

        [Required(ErrorMessage = "O Código é obrigatório")]
        public int Id { get; set; }

        public string NumeroOS { get; set; }

        [Required(ErrorMessage = "O Contrato é obrigatório")]
        public int IdContrato { get; set; }

        [Required(ErrorMessage = "O Serviço é obrigatório")]
        public int IdServico { get; set; }

        [Required(ErrorMessage = "O Prestador é obrigatório")]
        public int IdPrestador { get; set; }

        [Required(ErrorMessage = "A Data de Execução é obrigatória")]
        [DataType(DataType.Date, ErrorMessage = "Insira uma Data de Execução válida")]
        public DateTime? DataExecucao { get; set; }

        [Required(ErrorMessage = "O Valor do Serviço é obrigatório")]
        public string ValorServico { get; set; }
    }
}