using System.ComponentModel.DataAnnotations;

namespace Veterinari_di_italia.Models
{
    public class GestioneRicoveri
    {
        [Key]
        public int IdRicovero { get; set; }

        [Required]
        public DateTime DataRicovero { get; set; }

        [Required]
        public bool Ricoverato { get; set; }

        [Required]
        public required string DescrizioneAnimale { get; set; }

        public AnagraficaAnimale AnagraficaAnimale { get; set; }
    }
}
