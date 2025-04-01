using System.ComponentModel.DataAnnotations;

namespace Veterinari_di_italia.DTOs.Farmaci
{
    public class DeleteFarmaciResponseDTO
    {
        [Required]
        public required string Message { get; set; }
    }
}
