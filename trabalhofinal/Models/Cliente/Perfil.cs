using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace trabalhofinal.Models
{
    public class Perfil
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [HiddenInput(DisplayValue=false)]
        public int PerfilID { get; set; }

        [StringLength(50, ErrorMessage = "O campo nome deve conter entre 3 e 50 caracteres")]
        [Required]
        public string Nome { get; set; }
        public virtual ICollection<Acao> Acoes { get; set; }
    }
}