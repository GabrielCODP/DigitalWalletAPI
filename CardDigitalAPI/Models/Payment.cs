

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardDigitalAPI.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Amount { get; set; }

        [StringLength(10)]
        public string? Type { get; set; }
        public bool? IsApproved { get; set; }

        [ForeignKey("Buyer")]
        public int? BuyerId { get; set; }
        public Buyer? Buyer { get; set; }

        [ForeignKey("Boleto")]
        public int? BoletoId { get; set; }
        public Boleto? Boleto { get; set; }

        [ForeignKey("Card")]
        public int? CardId { get; set; }
        public Card? Card { get; set; }

    }
}
