using System.ComponentModel.DataAnnotations;

namespace Veterinari_di_italia.DTOs.GestioneRicoveri
{
    public class GetAllRicoveriResponseDto
    {
        [Required]
        public required string Message { get; set; }

        [Required]
        public required List<GestioneRicoveriDto>? Ricoveri { get; set; }
    }
}
