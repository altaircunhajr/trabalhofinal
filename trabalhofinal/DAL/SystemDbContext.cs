using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using trabalhofinal.Models;

namespace trabalhofinal.DAL
{
    public class SystemDbContext : DbContext
    {
        public SystemDbContext() : base("SystemContext") {}
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Item> ItensDePedidos { get; set; }
        public DbSet<Status> StatusDePedidos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Label> LabelsDeProdutos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> EnderecosDeCliente { get; set; }
        public DbSet<Perfil> PerfisDeUsuario { get; set; }
        public DbSet<Acao> Acoes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}