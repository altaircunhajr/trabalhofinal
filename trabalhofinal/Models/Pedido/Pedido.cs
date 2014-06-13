using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace trabalhofinal.Models
{
    public class Pedido
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PedidoID { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime Data { get; set; }
        
        public int ClienteID { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual ICollection<Item> Itens { get; set; }
        public double Total { get; set; }
        public virtual Status Status { get; set; }
        public static double TotalPedido(List<Item> Itens)
        {
            double Total = 0;
            Itens.ForEach(s => Total += s.Total);

            return Total;
        }

    }
}