using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace trabalhofinal.Models
{
    public class Cliente
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClienteID { get; set; }
        
        [Display(Name="Nome")]
        public string PrimeiroNome { get; set; }
        
        [Display(Name = "Sobrenome")]
        public string Sobrenome { get; set; }
        
        [Required]
        [StringLength(11, ErrorMessage = "O CPF deve conter entre 9 e 11 dígitos")]
        [Display(Name = "CPF")]
        public string Cpf { get; set; }
        
        [Display(Name = "Data de nascimento")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }
        
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
        [Display(Name = "Fone")]
        [DisplayFormat(DataFormatString="{0:(##) ####-####}", ApplyFormatInEditMode=true)]
        [DataType(DataType.PhoneNumber)]
        public string Telefone { get; set; }

        [Display(Name = "Celular")]
        [DataType(DataType.PhoneNumber)]
        [DisplayFormat(DataFormatString = "{0:(##) ####-####}", ApplyFormatInEditMode = true)]
        public string Celular { get; set; }

        public int EnderecoID { get; set; }
        public virtual Endereco Endereco { get; set; }

        [Display(Name = "Usuario")]
        [Editable(false)]
        public int UsuarioID { get; set; }
        public virtual Usuario Usuario { get; set; }
        
        public virtual ICollection<Pedido> Pedidos { get; set; }

    }
}