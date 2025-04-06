using CardDigitalAPI.Validations;
using System.ComponentModel.DataAnnotations;

namespace CardDigitalAPI.DTOS.BuyerDTOs
{
    public class BuyerUpdateRequestDTO
    {
        [Key]
        [Required(ErrorMessage = "Id é obrigatório")]
        public int BuyerId { get; set; }

        [Required(ErrorMessage = "Name do buyer é obrigatório!")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "O nome deve ter no máximo {1} caracteres e no mínimo {2}")]
        public string? NameBuyer { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório")]
        [StringLength(11)]
        [ValidarCPFBuyer]
        public string? Cpf { get; set; }
    }
}
