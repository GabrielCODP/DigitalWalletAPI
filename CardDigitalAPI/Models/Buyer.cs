using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace CardDigitalAPI.Models
{
    public class Buyer
    {
        [Key]
        public int BuyerId { get; set; }

        [StringLength(50)]
        public string? NameBuyer { get; set; }

        [StringLength(11)]
        public string? Cpf { get; set; }
        public ICollection<Client>? Clients { get; set; }
        public Buyer()
        {
            Clients = new Collection<Client>();
        }
    }
}
