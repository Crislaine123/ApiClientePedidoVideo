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
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;
        private readonly IMapper _mapper;
        private readonly IClienteService _clienteService;

        public PedidoController(IPedidoService pedidoService, IMapper mapper, IClienteService clienteService)
        {
            _pedidoService = pedidoService;
            _mapper = mapper;
            _clienteService = clienteService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<PedidoReadDto>>> Get()
        {
            var pedidos = await _pedidoService.GetAll();
            return Ok(_mapper.Map<IEnumerable<PedidoReadDto>>(pedidos));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PedidoReadDto>> GetById(int id)
        {
            var pedido = await _pedidoService.GetById(id);

            if(pedido == null) return NotFound();

            return Ok(_mapper.Map<PedidoReadDto>(pedido));
        }


        [HttpPost]
        public async Task<ActionResult<PedidoReadDto>> Post(PedidoCreateEditDto dto)
        {
            var clienteExistente = await _clienteService.GetById(dto.ClienteId);

            if (clienteExistente == null)
            {
                return NotFound("Cliente não localizado!");
            }

            var pedido = _mapper.Map<Pedido>(dto);
            var criado = await _pedidoService.Create(pedido);

            var pedidoRead = _mapper.Map<PedidoReadDto>(criado);

            return CreatedAtAction(nameof(GetById), new { id = pedidoRead.Id }, pedidoRead);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, PedidoCreateEditDto dto)
        {
            var pedidoExistente = await _pedidoService.GetById(id);

            if (pedidoExistente == null) return NotFound();

            _mapper.Map(dto, pedidoExistente);

            await _pedidoService.Update(pedidoExistente);

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
           var resultado = await _pedidoService.Delete(id);
           return resultado ? NoContent() : NotFound();
        }

    }
}
