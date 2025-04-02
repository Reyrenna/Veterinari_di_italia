using System.ComponentModel.DataAnnotations;

namespace Veterinari_di_italia.DTOs.VisiteVeterinarie
{
    public class GetAllVisiteByAnimalIdResponseDto
    {
        [Required]
        public required string Message { get; set; }

        [Required]
        public List<VisiteVeterinarieSimpleDto>? Visite { get; set; }
    }
}
