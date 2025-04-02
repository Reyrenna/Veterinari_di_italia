using System.ComponentModel.DataAnnotations.Schema;
using Veterinari_di_italia.DTOs.Farmacia;

namespace Veterinari_di_italia.DTOs.FarmaciaVisiteVeterinarie
{
    public class GetFarmaciFarmaciaVisiteVeterinarieDto
    {
        public Guid FarmacoId { get; set; }

        // navigazione
        [ForeignKey(nameof(FarmacoId))]
        public FarmaciaSimpleDto Farmaco { get; set; }
    }
}
