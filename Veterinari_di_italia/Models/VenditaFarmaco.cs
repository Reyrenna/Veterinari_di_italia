using System.ComponentModel.DataAnnotations;

namespace Veterinari_di_italia.Models
{
    public class VenditaFarmaco
    {
        [Key]
        public Guid IdVendita {  get; set; }

        public string? NumeroRicetta { get; set; }

        [Required]
        public DateTime DataAcquisto {  get; set; }
        
        public ApplicationUser Acquirente { get; set; }

        public ICollection<Farmacia> Farmacia { get; set; }
    }
}
