using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using trabalhofinal.Models;

namespace trabalhofinal.DAL
{
    public class DbInitializer : DropCreateDatabaseAlways<SystemDbContext>
    {
        protected override void Seed(SystemDbContext context)
        {

            var acoes = new List<Acao> 
            { 
                new Acao{ Nome="gerenciar_produtos" },
                new Acao{ Nome="gerenciar_pedidos" },
                new Acao{ Nome="comprar_produtos" },
            };

            acoes.ForEach(s => context.Acoes.Add(s));
            context.SaveChanges();

            var perfis = new List<Perfil> 
            { 
                new Perfil{ Nome="gerente_master", Acoes=acoes },
                new Perfil{ Nome="gerente_produtos", Acoes=new List<Acao> {acoes.ElementAt(0)} },
                new Perfil{ Nome="gerente_pedidos", Acoes=new List<Acao> {acoes.ElementAt(1)} },
                new Perfil{ Nome="cliente", Acoes=new List<Acao> {acoes.ElementAt(2)} },
            };

            perfis.ForEach(s => context.PerfisDeUsuario.Add(s));
            context.SaveChanges();

            var usuarios = new List<Usuario> 
            {
                new Usuario{ Login="altair.cunha", Senha="123456", Perfis=new List<Perfil> { perfis.ElementAt(0), perfis.ElementAt(3) } },
                new Usuario{ Login="everson.araujo", Senha="123456", Perfis=new List<Perfil> { perfis.ElementAt(0), perfis.ElementAt(3) } },
                new Usuario{ Login="anderson.silva", Senha="123456", Perfis=new List<Perfil> { perfis.ElementAt(1) } },
                new Usuario{ Login="andre.filipe", Senha="123456", Perfis=new List<Perfil> { perfis.ElementAt(3) } },
            };

            usuarios.ForEach(s => context.Usuarios.Add(s));
            context.SaveChanges();

            var enderecos = new List<Endereco>
            {
                new Endereco{EnderecoID=70790060, Rua="Asa Norte", Cidade="Brasília", Estado="DF"}
            };

            enderecos.ForEach(s => context.EnderecosDeCliente.Add(s));
            context.SaveChanges();

            var clientes = new List<Cliente>
            {
                new Cliente{PrimeiroNome="Altair", Sobrenome="Carneiro da Cunha Júnior", Celular="85805981", Telefone="32174558", Cpf="00231276192", DataNascimento=DateTime.Parse("1983-06-11"),Email="acc-junior@hotmail.com",Endereco=enderecos.ElementAt(0), Usuario=usuarios.ElementAt(0) }
            };

            clientes.ForEach(s => context.Clientes.Add(s));
            context.SaveChanges();

            var labels = new List<Label>
            {
                new Label{Nome="Fruta",Especial=true},
                new Label{Nome="Verdura",Especial=true},
                new Label{Nome="Integral",Especial=true},
                new Label{Nome="Frios",Especial=true},
                new Label{Nome="Farinha",Especial=true},
            };

            labels.ForEach(s => context.LabelsDeProdutos.Add(s));
            context.SaveChanges();

            var produtos = new List<Produto>
            {
                new Produto{ Nome="Banana da Terra", Fabricante="Fazenda Formosa", Imagem="default.png", Preco=5.5, Quantidade=200, Unidade="kg", Labels=new List<Label> {labels.ElementAt(0)} },
                new Produto{ Nome="Fubá", Fabricante="Mainha", Imagem="default.png", Preco=0.5, Quantidade=200, Unidade="pct", Labels=new List<Label> {labels.ElementAt(4)} }
            };

            produtos.ForEach(s => context.Produtos.Add(s));
            context.SaveChanges();

            var statusDePedidos = new List<Status> 
            {
                new Status{ Descricao="Confirmado" },
                new Status{ Descricao="Em fila para entrega" },
                new Status{ Descricao="Entregue" },
                new Status{ Descricao="Cancelado" }
            };

            statusDePedidos.ForEach(s => context.StatusDePedidos.Add(s));
            context.SaveChanges();

            var itensDePedido = new List<Item> 
            {
                new Item{Produto=produtos.ElementAt(0),Quantidade=5,Total=(produtos.ElementAt(0).Preco * 5)},
                new Item{Produto=produtos.ElementAt(1),Quantidade=10,Total=(produtos.ElementAt(1).Preco * 10)}
            };

            itensDePedido.ForEach(s => context.ItensDePedidos.Add(s));
            context.SaveChanges();

            var pedidos = new List<Pedido> 
            {
                new Pedido{Cliente=clientes.ElementAt(0),Data=DateTime.Parse("2014-06-10"),
                    Itens=itensDePedido,Status=statusDePedidos.ElementAt(0),Total=Pedido.TotalPedido(itensDePedido)}
            };

            pedidos.ForEach(s => context.Pedidos.Add(s));
            context.SaveChanges();
        }
    }
}