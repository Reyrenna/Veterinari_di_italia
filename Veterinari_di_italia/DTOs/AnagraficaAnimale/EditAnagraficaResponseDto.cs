using System.ComponentModel.DataAnnotations;

namespace Veterinari_di_italia.DTOs.AnagraficaAnimale
{
    public class EditAnagraficaResponseDto
    {
        [Required]
        public required string Message { get; set; }
    }
}
