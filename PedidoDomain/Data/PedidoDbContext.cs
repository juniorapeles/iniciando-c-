using Microsoft.EntityFrameworkCore;
using PedidoDomain.Models;

namespace PedidoDomain.Data;

public class PedidoDbContext : DbContext
{
    public PedidoDbContext(DbContextOptions<PedidoDbContext> options)
        : base(options)
    {
    }

    public DbSet<Produto> Produtos { get; set; }

    public DbSet<Pedido> Pedidos { get; set; }

    public DbSet<ItemPedido> ItensPedido { get; set; }

    public DbSet<Cliente> Clientes { get; set; }
}