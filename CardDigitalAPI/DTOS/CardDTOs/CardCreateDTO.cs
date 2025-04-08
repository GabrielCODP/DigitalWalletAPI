using System.ComponentModel.DataAnnotations;

namespace CardDigitalAPI.DTOS.CardDTOs
{
    public class CardCreateDTO
    {
        [Required]
        [StringLength(30, ErrorMessage = "O nome do card é obrigatório")]
        public string? CardHolderName { get; set; }

        [Required]
        [StringLength(16, ErrorMessage = "O número do card é obrigatório")]
        [RegularExpression(@"^\d{16}$", ErrorMessage = "O código de barras deve conter exatamente 16 dígitos numéricos.")]
        public string? CardNumber { get; set; }

        [Required]
        [StringLength(3, ErrorMessage = "O número CVV é obrigatório")]
        public string? CVV { get; set; }

        [Required]
        public DateTime ExpirationDate { get; set; }
    }
}
