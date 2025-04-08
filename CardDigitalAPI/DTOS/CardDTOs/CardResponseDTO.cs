using System.ComponentModel.DataAnnotations;

namespace CardDigitalAPI.DTOS.CardDTOs
{
    public class CardResponseDTO
    {
        public int CardId { get; set; }
        public string? CardHolderName { get; set; }
        public string? CardNumber { get; set; }
        public string? CVV { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
