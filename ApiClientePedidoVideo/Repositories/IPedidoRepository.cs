using ApiClientePedidoVideo.Models;

namespace ApiClientePedidoVideo.Repositories
{
    public interface IPedidoRepository
    {
        Task<IEnumerable<Pedido>> GetAllAsync();
        Task<Pedido> GetByIdAsync(int id);
        Task AddAsync(Pedido pedido);
        Task UpdateAsync(Pedido pedido);
        Task DeleteAsync(Pedido pedido);
        Task<bool> SaveAsync();
    }
}
