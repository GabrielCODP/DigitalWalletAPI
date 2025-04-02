using System.ComponentModel.DataAnnotations;

namespace CardDigitalAPI.Models
{
    public class Card
    {
        [Key]
        public int CardId { get; set; }
        [StringLength(30)]
        public string? CardHolderName { get; set; }
        [StringLength(16)]
        public string? CardNumber { get; set; }
        [StringLength(3)]
        public string? CVV { get; set; }
        public DateTime ExpirationDate { get; set; }

        public int? PaymentId { get; set; }
        public Payment? Payment { get; set; }


    }
}
