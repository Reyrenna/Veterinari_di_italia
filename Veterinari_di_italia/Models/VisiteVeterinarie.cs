using System.ComponentModel.DataAnnotations;

namespace Veterinari_di_italia.Models
{
    public class VisiteVeterinarie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime DataDellaVisita { get; set; }
        [Required]
        public string EsameObiettivo { get; set; }
        [Required]
        public string Descrizione { get; set; }

        public ICollection<Farmacia> Farmaci { get; set; }

        public AnagraficaAnimale AnagraficaAnimale { get; set; }
    }
}
