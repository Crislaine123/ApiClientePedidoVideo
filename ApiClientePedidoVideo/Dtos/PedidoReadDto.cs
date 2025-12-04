using ApiClientePedidoVideo.Models;

namespace ApiClientePedidoVideo.Dtos
{
    public class PedidoReadDto
    {
        public int Id { get; set; }
        public DateTime DataPedido { get; set; }
        public decimal ValorTotal { get; set; }
        public string Status { get; set; }
        public int ClienteId { get; set; }
        public string NomeCliente { get; set; }
    }
}
