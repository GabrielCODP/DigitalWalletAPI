using AutoMapper;
using CardDigitalAPI.DTOS.ClientDTOs;
using CardDigitalAPI.Models;

namespace CardDigitalAPI.DTOS.MappingDTO
{
    public class DadosDTOMappingProfile : Profile
    {
        public DadosDTOMappingProfile() 
        {
            CreateMap<Client, ClientResponseDTO>().ReverseMap();
            CreateMap<Client, ClientCreateDTO>().ReverseMap();
            CreateMap<Client, ClientUpdateRequestDTO>().ReverseMap();
        }
    }
}
