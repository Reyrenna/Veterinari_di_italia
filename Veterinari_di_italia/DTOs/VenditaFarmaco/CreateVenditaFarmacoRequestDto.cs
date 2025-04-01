using System.ComponentModel.DataAnnotations;

namespace Veterinari_di_italia.DTOs.VenditaFarmaco
{
    public class CreateVenditaFarmacoRequestDto
    {
        [Required]
        public required string NumeroRicetta { get; set; }

        [Required]
        public DateTime DataAcquisto { get; set; }

        [Required]
        public required string AcquirenteId { get; set; }
    }
}
