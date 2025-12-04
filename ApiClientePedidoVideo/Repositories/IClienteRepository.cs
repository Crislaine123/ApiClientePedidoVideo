using ApiClientePedidoVideo.Models;

namespace ApiClientePedidoVideo.Repositories
{
    public interface IClienteRepository
    {

        Task<IEnumerable<Cliente>> GetAllAsync();
        Task<Cliente> GetByIdAsync(int id);
        Task AddAsync(Cliente cliente);
        Task UpdateAsync(Cliente cliente);
        Task DeleteAsync(Cliente cliente);
        Task<bool> SaveAsync();

    }
}
