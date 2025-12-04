using ApiClientePedidoVideo.Models;

namespace ApiClientePedidoVideo.Services
{
    public interface IPedidoService
    {
        Task<IEnumerable<Pedido>> GetAll();
        Task<Pedido> GetById(int id);
        Task<Pedido> Create(Pedido pedido);
        Task<bool> Update(Pedido pedido);
        Task<bool> Delete(int id);
    }
}
