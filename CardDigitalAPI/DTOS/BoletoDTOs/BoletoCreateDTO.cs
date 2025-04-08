using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CardDigitalAPI.DTOS.BoletoDTOs
{
    public class BoletoCreateDTO
    {
        [Required]
        [StringLength(48)]
        [RegularExpression(@"^\d{48}$", ErrorMessage = "O código de barras deve conter exatamente 48 dígitos numéricos.")]
        public string? BoletoNumber { get; set; }

        [Required]
        [StringLength(44)]
        [RegularExpression(@"^\d{44}$", ErrorMessage = "O código de barras deve conter exatamente 44 dígitos numéricos.")]
        public string? Barcode { get; set; }

        [JsonIgnore]
        public DateTime ExpirationDate { get; set; } = DateTime.UtcNow.AddDays(5);

        [JsonIgnore]
        public bool BoletoPago { get; set; } = false;

        [Required]
        public int PaymentId { get; set; }


    }
}
