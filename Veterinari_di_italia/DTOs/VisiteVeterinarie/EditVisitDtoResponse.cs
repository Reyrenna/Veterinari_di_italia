using System.ComponentModel.DataAnnotations;

namespace Veterinari_di_italia.DTOs.VisiteVeterinarie
{
    public class EditVisitDtoResponse
    {
        [Required]
        public required string Message { get; set; }
    }
}
