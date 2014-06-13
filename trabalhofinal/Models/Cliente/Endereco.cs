
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace trabalhofinal.Models
{
    public class Endereco
    {
        [Display(Name = "CEP")]
        [Required(ErrorMessage = "O campo CEP é obrigatório")]
        public int EnderecoID { get; set; }

        [Display(Name = "Rua")]
        [StringLength(50, ErrorMessage = "O campo Rua deve conter entre 4 e 50 dígitos")]
        [Required(AllowEmptyStrings = false)]
        public string Rua { get; set; }

        [Display(Name = "Estado")]
        public string Estado { get; set; }

        [Display(Name = "Cidade")]
        [StringLength(50, ErrorMessage = "O campo Cidade deve conter entre 4 e 50 dígitos")]
        [Required(AllowEmptyStrings=false)] // TODO: Incluir validação de mínimo de caracteres
        public string Cidade { get; set; }
    }
}