using System.ComponentModel.DataAnnotations;

namespace Veterinari_di_italia.DTOs.AnagraficaAnimale
{
    public class CreateAnagraficaResponseDto
    {
        [Required]
        public required string Message { get; set; }
    }
}
