using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Veterinari_di_italia.Models
{
    public class FarmaciaVisiteVeterinarie
    {
        [Key]
        public Guid FarmaciaVisiteVeterinarieId { get; set; }

        public Guid FarmacoId { get; set; }

        public int VisitaId { get; set; }

        // navigazione
        [ForeignKey(nameof(FarmacoId))]
        public Farmacia Farmaco { get; set; }

        [ForeignKey(nameof(VisitaId))]
        public VisiteVeterinarie Visita { get; set; }
    }
}
