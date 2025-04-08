using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CardDigitalAPI.DTOS.PaymentDTOs
{
    public class PaymentResponseDTO
    {
        public int PaymentId { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreateDate { get; set; }
        public bool? IsApproved { get; set; } = false;
        public int BuyerId { get; set; }
        public string? NameBuyer { get; set; }
    }
}
