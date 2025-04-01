using System.ComponentModel.DataAnnotations;

namespace Veterinari_di_italia.DTOs.AnagraficaAnimale
{
    public class GetAllAnagraficheResponseDto
    {
        [Required]
        public required string Message { get; set; }

        [Required]
        public required List<AnagraficaDto>? Anagrafiche { get; set; }
    }
}
