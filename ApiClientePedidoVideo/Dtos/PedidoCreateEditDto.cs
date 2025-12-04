namespace ApiClientePedidoVideo.Dtos
{
    public class PedidoCreateEditDto
    {
        public decimal ValorTotal { get; set; }
        public string Status { get; set; }
        public int ClienteId { get; set; }
    }
}
