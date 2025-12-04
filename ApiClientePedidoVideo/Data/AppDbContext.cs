using ApiClientePedidoVideo.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiClientePedidoVideo.Data
{
    public class AppDbContext : DbContext
    {


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pedido> Pedidos
        {
            get; set;


        }
    }
}
