using System.ComponentModel.DataAnnotations;

namespace Veterinari_di_italia.DTOs.VenditaFarmaco
{
    public class GetVenditaFarmacoByIdResponseDto
    {
        [Required]
        public required string Message { get; set; }

        [Required]
        public required VenditaFarmacoDto? Vendita { get; set; }
    }
}
