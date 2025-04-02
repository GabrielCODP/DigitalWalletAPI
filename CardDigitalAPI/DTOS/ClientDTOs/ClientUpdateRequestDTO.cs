using System.ComponentModel.DataAnnotations;

namespace CardDigitalAPI.DTOS.ClientDTOs
{
    public class ClientUpdateRequestDTO
    {
        [Required(ErrorMessage = "O ID da linha é obrigatório")]
        public int ClientId { get; set; }

        [Required(ErrorMessage = "O nome do Client é obrigatorio.")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "O nome deve ter no máximo {1} caracteres e no mínimo {2}")]
        public string? NameClient { get; set; }
    }
}
