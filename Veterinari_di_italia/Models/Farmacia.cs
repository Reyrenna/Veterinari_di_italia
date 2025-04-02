using System.ComponentModel.DataAnnotations;

namespace Veterinari_di_italia.Models
{
    public class Farmacia
    {
        [Key]
        public Guid IdFarmaco { get; set; }

        [Required]
        public required string Nome { get; set; }

        [Required]
        public required string DittaFornitrice { get; set; }

        [Required]
        public required string ElencoUsi { get; set; }

        [Required]
        public required bool Farmaco { get; set; }

        [Required]
        public required string Posizione { get; set; }

        public List<FarmaciaVenditaFarmaco>? FarmaciaVenditaFarmaco { get; set; }

        public List<FarmaciaVisiteVeterinarie>? FarmaciaVisiteVeterinaries { get; set; }
    }
}
