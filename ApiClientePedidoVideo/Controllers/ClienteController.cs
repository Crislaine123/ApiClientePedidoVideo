using ApiClientePedidoVideo.Dtos;
using ApiClientePedidoVideo.Models;
using ApiClientePedidoVideo.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiClientePedidoVideo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        private readonly IMapper _mapper;

        public ClienteController(IClienteService clienteService, IMapper mapper)
        {
            _clienteService = clienteService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteReadDto>>> Get()
        {
            var clientes = await _clienteService.GetAll();
            return Ok(_mapper.Map<IEnumerable<ClienteReadDto>>(clientes));
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteReadDto>> GetById(int id)
        {
            var cliente = await _clienteService.GetById(id);

            return Ok(_mapper.Map<ClienteReadDto>(cliente));
        }

        [HttpPost]
        public async Task<ActionResult<ClienteReadDto>> Post(ClienteCreateEditDto dto)
        {
            var cliente = _mapper.Map<Cliente>(dto);

            await _clienteService.Create(cliente);

            var clienteRead = _mapper.Map<ClienteReadDto>(cliente);

            return CreatedAtAction(nameof(GetById), new {id = cliente.Id}, clienteRead);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ClienteCreateEditDto dto)
        {
           var clienteExistente = await _clienteService.GetById(id);

            if (clienteExistente == null)
                return NotFound();

            _mapper.Map(dto, clienteExistente);

            await _clienteService.Update(clienteExistente);

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var resultado = await _clienteService.Delete(id);

            return resultado ? NoContent() : NotFound();

        }


    }
}
