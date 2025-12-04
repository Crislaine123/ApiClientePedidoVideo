using ApiClientePedidoVideo.Models;
using ApiClientePedidoVideo.Repositories;

namespace ApiClientePedidoVideo.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repo;  
        public ClienteService(IClienteRepository repo)
        {
            _repo = repo;
        }



        public async Task<IEnumerable<Cliente>> GetAll()
         => await _repo.GetAllAsync();
        public Task<Cliente> GetById(int id)
        => _repo.GetByIdAsync(id);
        public async Task<Cliente> Create(Cliente cliente)
        {
            await _repo.AddAsync(cliente);
            await _repo.SaveAsync();

            return cliente;

        }
        public async Task<bool> Delete(int id)
        {
            var cliente = await _repo.GetByIdAsync(id);
            if (cliente == null) return false;

            await _repo.DeleteAsync(cliente);
            return await _repo.SaveAsync(); 
        }      
        public async Task<bool> Update(Cliente cliente)
        {
            await _repo.UpdateAsync(cliente);
            return await _repo.SaveAsync();
        }
    }
}
