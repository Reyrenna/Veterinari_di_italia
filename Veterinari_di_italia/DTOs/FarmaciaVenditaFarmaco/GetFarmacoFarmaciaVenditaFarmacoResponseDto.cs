using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Veterinari_di_italia.DTOs.Farmacia;
using Veterinari_di_italia.DTOs.VenditaFarmaco;

namespace Veterinari_di_italia.DTOs.FarmaciaVenditaFarmaco
{
    public class GetFarmacoFarmaciaVenditaFarmacoResponseDto
    {
        public required Guid VenditaFarmacoIdVendita { get; set; }

        // navigazione
        [ForeignKey(nameof(VenditaFarmacoIdVendita))]
        public VenditaFarmacoSimpleDto VenditaFarmaco { get; set; }
    }
}
