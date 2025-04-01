using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Veterinari_di_italia.DTOs.Account;
using Veterinari_di_italia.DTOs.Farmacia;
using Veterinari_di_italia.Models;

namespace Veterinari_di_italia.DTOs.VenditaFarmaco
{
    public class VenditaFarmacoDto
    {
        [Key]
        public Guid IdVendita { get; set; }

        public string? NumeroRicetta { get; set; }

        [Required]
        public DateTime DataAcquisto { get; set; }

        public string? AcquirenteId { get; set; }

        [ForeignKey(nameof(AcquirenteId))]
        public UserSimpleDto Acquirente { get; set; }

        public ICollection<FarmaciaSimpleDto>? Farmacia { get; set; }
    }
}
