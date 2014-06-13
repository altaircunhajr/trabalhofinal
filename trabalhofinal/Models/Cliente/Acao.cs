using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace trabalhofinal.Models
{
    public class Acao
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AcaoID { get; set; }
        public string Nome { get; set; }
    }
}