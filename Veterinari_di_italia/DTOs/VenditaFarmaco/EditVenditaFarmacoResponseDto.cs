using System.ComponentModel.DataAnnotations;

namespace Veterinari_di_italia.DTOs.VenditaFarmaco
{
    public class EditVenditaFarmacoResponseDto
    {
        [Required]
        public required string Message { get; set; }
    }
}
