using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace CardDigitalAPI.Models
{
    public class Client
    {
        [Key]
        public int ClientId { get; set; }

        [StringLength(50)]
        public string? NameClient { get; set; }
        public ICollection<Buyer>? Buyers { get; set; }

        public Client()
        {
            Buyers = new Collection<Buyer>();
        }

    }
}
