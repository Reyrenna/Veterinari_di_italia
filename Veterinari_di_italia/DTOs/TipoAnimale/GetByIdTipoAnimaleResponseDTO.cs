using System.ComponentModel.DataAnnotations;

namespace Veterinari_di_italia.DTOs.TipoAnimale
{
    public class GetByIdTipoAnimaleResponseDTO
    {
        [Required]
        public required string Message { get; set; }

        [Required]

        public TipologiaICollection Tipologia { get; set; }
    }
}
