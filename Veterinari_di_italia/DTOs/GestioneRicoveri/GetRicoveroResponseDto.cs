using System.ComponentModel.DataAnnotations;

namespace Veterinari_di_italia.DTOs.GestioneRicoveri
{
    public class GetRicoveroResponseDto
    {
        [Required]
        public required string Message { get; set; }

        [Required]
        public required GestioneRicoveriDto? Ricovero { get; set; }
    }
}
