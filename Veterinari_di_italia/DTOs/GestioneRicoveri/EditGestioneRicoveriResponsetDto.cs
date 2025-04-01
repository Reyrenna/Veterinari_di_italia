using System.ComponentModel.DataAnnotations;

namespace Veterinari_di_italia.DTOs.GestioneRicoveri
{
    public class EditGestioneRicoveriResponsetDto
    {
        [Required]
        public required string Message { get; set; }
    }
}
