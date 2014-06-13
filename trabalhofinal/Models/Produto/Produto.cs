using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace trabalhofinal.Models
{
    public class Produto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProdutoID { get; set; }
        
        [Display(Name = "Quantidade")]
        [Range(0, Int32.MaxValue, ErrorMessage="A quantidade não pode ser negativa")]
        public int Quantidade { get; set; }

        [Display(Name = "Fabricante/Marca")]
        [Required(ErrorMessage="Campo não pode ser vazio")]
        public string Fabricante { get; set; }

        [Display(Name = "Imagem")]
        [DefaultValue("default.png")]
        public string Imagem { get; set; }

        [Display(Name = "Nome")]
        [StringLength(50, ErrorMessage="O campo nome deve conter entre 3 e 50 caracteres")]
        [Required(AllowEmptyStrings=false)]
        public string Nome { get; set; }

        [Display(Name = "Preço")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Campo não pode ser vazio")]
        public double Preco { get; set; }

        [Display(Name = "Unidade")]
        [Required(ErrorMessage = "Campo não pode ser vazio")]
        public string Unidade { get; set; }
        public virtual ICollection<Label> Labels { get; set; }
    }
}