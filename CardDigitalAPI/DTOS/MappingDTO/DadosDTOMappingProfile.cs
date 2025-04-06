using AutoMapper;
using CardDigitalAPI.DTOS.BuyerDTOs;
using CardDigitalAPI.DTOS.ClientDTOs;
using CardDigitalAPI.Models;

namespace CardDigitalAPI.DTOS.MappingDTO
{
    public class DadosDTOMappingProfile : Profile
    {
        public DadosDTOMappingProfile() 
        {
            CreateMap<Client, ClientCreateDTO>().ReverseMap();
            CreateMap<Client, ClientUpdateRequestDTO>().ReverseMap();
            CreateMap<Client, ClientResponseDTO>().ReverseMap();

            CreateMap<Buyer, BuyerCreateDTO>().ReverseMap();
            CreateMap<Buyer,BuyerUpdateRequestDTO>().ReverseMap();
            CreateMap<Buyer, BuyerResponseDTO>().ReverseMap();
        }
    }
}
