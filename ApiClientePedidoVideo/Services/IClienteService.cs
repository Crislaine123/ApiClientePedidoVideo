using ApiClientePedidoVideo.Models;

namespace ApiClientePedidoVideo.Services
{
    public interface IClienteService
    {
        Task<IEnumerable<Cliente>> GetAll();
        Task<Cliente> GetById(int id);
        Task<Cliente> Create(Cliente cliente);
        Task<bool> Update(Cliente cliente);
        Task<bool> Delete(int id);
    }
}
