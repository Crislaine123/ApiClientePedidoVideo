using ApiClientePedidoVideo.Data;
using ApiClientePedidoVideo.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiClientePedidoVideo.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly AppDbContext _context;

        public PedidoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Pedido>> GetAllAsync()
        => await _context.Pedidos.Include(c => c.Cliente).ToListAsync();
        public async Task<Pedido> GetByIdAsync(int id)
        => await _context.Pedidos.Include(c => c.Cliente).FirstOrDefaultAsync(p => p.Id == id);
        public async Task AddAsync(Pedido pedido)
        {
            bool clienteExiste = _context.Clientes.Any(c => c.Id == pedido.ClienteId);

            if (!clienteExiste)
                throw new Exception("Cliente não existe.");
            

            await _context.Pedidos.AddAsync(pedido);

        }
        public Task DeleteAsync(Pedido pedido)
        {
            _context.Pedidos.Remove(pedido);
            return Task.CompletedTask;  
        }      
        public async Task<bool> SaveAsync()
         => await _context.SaveChangesAsync() > 0;
        public Task UpdateAsync(Pedido pedido)
        {
            _context.Pedidos.Update(pedido);
            return Task.CompletedTask;
        }
    }
}
