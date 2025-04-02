
using System.ComponentModel.DataAnnotations;

namespace CardDigitalAPI.Models
{
    public class Boleto 
    {
        [Key]
        public int BoletoId { get; set; }
        [StringLength(48)]
        public string? BoletoNumber { get; set; }
        public string? ExpirationDate { get; set; }
        [StringLength(44)]
        public string? Barcode { get; set; }

        public int? PaymentId { get; set; }
        public Payment? Payment { get; set; }

    }
}
