using CardDigitalAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace CardDigitalAPI.DTOS.BoletoDTOs
{
    public class BoletoResponseDTO
    {
        public int BoletoId { get; set; }
        public string? BoletoNumber { get; set; }
        public string? Barcode { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool BoletoPago { get; set; }
        public int PaymentId { get; set; }

    }
}
