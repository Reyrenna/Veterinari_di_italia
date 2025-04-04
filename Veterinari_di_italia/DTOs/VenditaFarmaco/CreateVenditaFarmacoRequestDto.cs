using System.ComponentModel.DataAnnotations;
using Veterinari_di_italia.DTOs.Farmacia;
using Veterinari_di_italia.DTOs.FarmaciaVenditaFarmaco;
using Veterinari_di_italia.Models;

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

        [Required]
        public required List<CreateVenditaFarmaciaVenditaFarmacoDto> FarmaciaVenditaFarmaco { get; set; }
    }
}
