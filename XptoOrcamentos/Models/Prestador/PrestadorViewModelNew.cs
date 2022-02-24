using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace XptoOrcamentos.Models.Prestador
{
    public class PrestadorViewModelNew
    {
        public List<SelectListItem> Empresas { get; set; }

        [Required(ErrorMessage = "A Empresa é obrigatória")]
        public int IdEmpresa { get; set; }

        [Required(ErrorMessage = "O Nome é obrigatório")]
        [StringLength(150)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório")]
        [StringLength(11)]
        public String CPF { get; set; }
        
    }
}
