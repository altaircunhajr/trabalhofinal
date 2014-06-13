using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace trabalhofinal.Models
{
    public class Item
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemID { get; set; }
        public int ProdutoID { get; set; }
        public virtual Produto Produto { get; set; }
        public int Quantidade { get; set; }
        public double Total { get; set; }
    }
}