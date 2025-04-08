using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardDigitalAPI.DTOS.PaymentDTOs
{
    public class PaymentUpdateRequestDTO
    {
        [Key]
        [Required]
        public int PaymentId { get; set; }

        [Required(ErrorMessage = "O valor é obrigatório")]
        [Range(0, 99999999.99, ErrorMessage = "O valor deve ser entre {0} e {1}")]
        public decimal Amount { get; set; }

        [Required]
        public int BuyerId { get; set; }
    }
}
