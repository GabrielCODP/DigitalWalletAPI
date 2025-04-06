using System.ComponentModel.DataAnnotations;

namespace CardDigitalAPI.DTOS.BuyerDTOs
{
    public class BuyerResponseDTO
    {
        public int BuyerId {  get; private set; }
        public string? NameBuyer { get; private set; }
        public string? Cpf { get; private set; }
    }
}
