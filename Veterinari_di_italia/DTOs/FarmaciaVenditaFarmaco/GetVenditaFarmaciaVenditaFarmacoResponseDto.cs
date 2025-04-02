using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Veterinari_di_italia.DTOs.Farmacia;

namespace Veterinari_di_italia.DTOs.FarmaciaVenditaFarmaco
{
    public class GetVenditaFarmaciaVenditaFarmacoResponseDto
    {
        public required Guid FarmaciaIdFarmaco { get; set; }

        // navigazione
        [ForeignKey(nameof(FarmaciaIdFarmaco))]
        public FarmaciaSimpleDto Farmaco { get; set; }
    }
}
