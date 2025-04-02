using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Veterinari_di_italia.Models
{
    public class VisiteVeterinarie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime DataDellaVisita { get; set; }

        [Required]
        public required string EsameObiettivo { get; set; }

        [Required]
        public required string Descrizione { get; set; }

        [Required]
        public required Guid IdAnimale { get; set; }

        public ICollection<Farmacia>? Farmaci { get; set; }

        [ForeignKey(nameof(IdAnimale))]
        public AnagraficaAnimale AnagraficaAnimale { get; set; }
    }
}
