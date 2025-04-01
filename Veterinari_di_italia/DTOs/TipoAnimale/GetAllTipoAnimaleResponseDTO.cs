using System.ComponentModel.DataAnnotations;

namespace Veterinari_di_italia.DTOs.TipoAnimale
{
    public class GetAllTipoAnimaleResponseDTO
    {
        [Required]
        public required string Message { get; set; }
    }
}
