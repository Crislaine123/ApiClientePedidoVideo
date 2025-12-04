namespace ApiClientePedidoVideo.Dtos
{
    public class ClienteReadDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public List<PedidoReadDto> Pedidos { get; set; }
    }
}
