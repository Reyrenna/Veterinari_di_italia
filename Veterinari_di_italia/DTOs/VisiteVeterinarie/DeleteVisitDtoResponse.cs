using System.ComponentModel.DataAnnotations;

namespace Veterinari_di_italia.DTOs.VisiteVeterinarie
{
    public class DeleteVisitDtoResponse
    {
        [Required]
        public required string Message { get; set; }
    }
}
