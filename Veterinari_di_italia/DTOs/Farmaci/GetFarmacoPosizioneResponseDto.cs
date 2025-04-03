using System.ComponentModel.DataAnnotations;

namespace Veterinari_di_italia.DTOs.Farmaci
{
    public class GetFarmacoPosizioneResponseDto
    {
        [Required]
        public required string Message { get; set; }

        [Required]
        public required string? Posizione { get; set; }
    }
}
