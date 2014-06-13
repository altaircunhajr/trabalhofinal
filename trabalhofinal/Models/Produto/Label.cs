using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace trabalhofinal.Models
{
    public class Label
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LabelID { get; set; }

        [Display(Name="Nome")]
        public string Nome { get; set; }

        public bool Especial { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; }
    }
}