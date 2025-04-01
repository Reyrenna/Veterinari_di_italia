using System.ComponentModel.DataAnnotations;

namespace Veterinari_di_italia.DTOs.VenditaFarmaco
{
    public class VenditaFarmacoSimpleDto
    {
        [Required]
        public Guid IdVendita { get; set; }

        public string? NumeroRicetta { get; set; }

        [Required]
        public DateTime DataAcquisto { get; set; }
    }
}
