using System.ComponentModel.DataAnnotations;

namespace CardDigitalAPI.DTOS.ClientDTOs
{
    public class ClientResponseDTO
    {
        public int ClientId { get; private set; }
        public string? NameClient { get; private set; }
    }
}
