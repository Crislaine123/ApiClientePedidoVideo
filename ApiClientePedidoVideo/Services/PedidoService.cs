using ApiClientePedidoVideo.Models;
using ApiClientePedidoVideo.Repositories;

namespace ApiClientePedidoVideo.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _repo;

        public PedidoService(IPedidoRepository repo)
        {
            _repo = repo;
        }

        public async Task<Pedido> Create(Pedido pedido)
        {
            pedido.DataPedido = DateTime.Now;

            await _repo.AddAsync(pedido);
            await _repo.SaveAsync();

            return pedido;
        }

        public async Task<bool> Delete(int id)
        {
            var pedido = await _repo.GetByIdAsync(id);

            if(pedido == null)
                return false;

            await _repo.DeleteAsync(pedido);
            return await _repo.SaveAsync();

        }

        public async Task<IEnumerable<Pedido>> GetAll()
        => await _repo.GetAllAsync();

        public async Task<Pedido> GetById(int id)
        => await _repo.GetByIdAsync(id);

        public async Task<bool> Update(Pedido pedido)
        {
            await _repo.UpdateAsync(pedido);
            return await _repo.SaveAsync();
        }
    }
}
