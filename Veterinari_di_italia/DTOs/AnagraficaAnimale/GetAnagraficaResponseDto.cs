using System.ComponentModel.DataAnnotations;

namespace Veterinari_di_italia.DTOs.AnagraficaAnimale
{
    public class GetAnagraficaResponseDto
    {
        [Required]
        public required string Message { get; set; }

        [Required]
        public required AnagraficaDto? Anagrafica { get; set; }
    }
}
