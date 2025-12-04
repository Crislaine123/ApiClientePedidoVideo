using ApiClientePedidoVideo.Data;
using ApiClientePedidoVideo.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiClientePedidoVideo.Repositories
{
    public class ClienteRepository : IClienteRepository
    {

        private readonly AppDbContext _context;
        public ClienteRepository(AppDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Cliente>> GetAllAsync()
            => await _context.Clientes.Include(p => p.Pedidos).ToListAsync();
        public async Task<Cliente> GetByIdAsync(int id)
            => await _context.Clientes
                    .Include(p => p.Pedidos)
                    .FirstOrDefaultAsync(c => c.Id == id);
        public async Task AddAsync(Cliente cliente)
        => await _context.Clientes.AddAsync(cliente);
        public Task UpdateAsync(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            return Task.CompletedTask;
        }
        public Task DeleteAsync(Cliente cliente)
        {
            _context.Clientes.Remove(cliente);
            return Task.CompletedTask;
        }
        public async Task<bool> SaveAsync()
        => await _context.SaveChangesAsync() > 0;


    }
}
