using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CardDigitalAPI.DTOS.PaymentDTOs
{
    public class PaymentCreateDTO
    {
        [Required(ErrorMessage = "O valor é obrigatório")]
        [Range(0, 99999999.99, ErrorMessage = "O valor deve ser entre {0} e {1}")]
        public decimal Amount { get; set; }

        [JsonIgnore]
        public bool? IsApproved { get; set; } = false;

        [JsonIgnore]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [Required]
        public int BuyerId { get; set; }
    }
}
