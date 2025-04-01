using System.ComponentModel.DataAnnotations;
using Veterinari_di_italia.DTOs.Farmacia;

namespace Veterinari_di_italia.DTOs.Farmaci
{
    public class GetAllFarmaciResponseDTO
    {
        [Required]
        public required string Message { get; set; }

        [Required]

        public List<FarmaciaSimpleDto>? Farmaci { get; set; }
    }
}
