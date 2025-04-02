using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Veterinari_di_italia.Models
{
    public class FarmaciaVenditaFarmaco
    {
        [Key]
        public Guid FarmaciaVenditaFarmacoId { get; set; }

        public required Guid FarmaciaIdFarmaco { get; set; }

        public required Guid VenditaFarmacoIdVendita { get; set; }

        // navigazione
        [ForeignKey(nameof(FarmaciaIdFarmaco))]
        public Farmacia Farmaco { get; set; }

        [ForeignKey(nameof(VenditaFarmacoIdVendita))]
        public VenditaFarmaco VenditaFarmaco { get; set; }
    }
}
