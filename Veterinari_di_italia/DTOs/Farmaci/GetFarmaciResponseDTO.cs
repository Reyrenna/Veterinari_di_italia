using System.ComponentModel.DataAnnotations;
using Veterinari_di_italia.DTOs.Farmacia;

namespace Veterinari_di_italia.DTOs.Farmaci
{
    public class GetFarmaciResponseDTO
    {
        [Required]
        public string Message { get; set; }

        [Required]

        public FarmaciaSimpleDto? Farmaci { get; set; }

    }
}
