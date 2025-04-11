using AutoMapper;
using CardDigitalAPI.DTOS.BoletoDTOs;
using CardDigitalAPI.DTOS.BuyerDTOs;
using CardDigitalAPI.DTOS.ClientDTOs;
using CardDigitalAPI.DTOS.PaymentDTOs;
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
            CreateMap<Buyer, BuyerUpdateRequestDTO>().ReverseMap();
            CreateMap<Buyer, BuyerResponseDTO>().ReverseMap();

            CreateMap<Payment, PaymentCreateDTO>().ReverseMap();
            CreateMap<Payment, PaymentUpdateRequestDTO>().ReverseMap();
            CreateMap<Payment, PaymentResponseDTO>().ReverseMap();

            CreateMap<Boleto, BoletoCreateDTO>().ReverseMap();
            CreateMap<Boleto, BoletoResponseDTO>().ReverseMap();
        }
    }
}
