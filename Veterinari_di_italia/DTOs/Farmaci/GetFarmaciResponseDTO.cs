using System.ComponentModel.DataAnnotations;

namespace Veterinari_di_italia.DTOs.Farmaci
{
    public class GetFarmaciResponseDTO
    {
        [Required]
        public string Message { get; set; }
        
    }
}
