using System.ComponentModel.DataAnnotations;
using Veterinari_di_italia.DTOs.Account;
using Veterinari_di_italia.DTOs.FarmaciaVenditaFarmaco;

namespace Veterinari_di_italia.DTOs.VenditaFarmaco
{
    public class EditVenditaFarmacoRequestDto
    {
        [Required]
        public required string NumeroRicetta { get; set; }

        [Required]
        public DateTime DataAcquisto { get; set; }

        [Required]
        public required string AcquirenteId { get; set; }

        [Required]

        public required List<CreateVenditaFarmaciaVenditaFarmacoDto>? Farmaco { get; set; }
    }
}
