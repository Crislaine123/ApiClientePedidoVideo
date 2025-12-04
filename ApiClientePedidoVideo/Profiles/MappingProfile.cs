using ApiClientePedidoVideo.Dtos;
using ApiClientePedidoVideo.Models;
using AutoMapper;

namespace ApiClientePedidoVideo.Profiles
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            //Cliente
            CreateMap<Cliente, ClienteReadDto>().ReverseMap();
            CreateMap<Cliente,ClienteCreateEditDto>().ReverseMap();

            //Pedido
            CreateMap<Pedido, PedidoReadDto>()
                .ForMember(dest => dest.NomeCliente, opt => opt.MapFrom(ped => ped.Cliente.Nome))
                .ReverseMap();

            CreateMap<Pedido,PedidoCreateEditDto>().ReverseMap();


        }


    }
}
