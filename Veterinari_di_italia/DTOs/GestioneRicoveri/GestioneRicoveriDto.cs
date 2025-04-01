using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Veterinari_di_italia.DTOs.AnagraficaAnimale;

namespace Veterinari_di_italia.DTOs.GestioneRicoveri
{
    public class GestioneRicoveriDto
    {
        [Key]
        public int IdRicovero { get; set; }

        [Required]
        public DateTime DataRicovero { get; set; }

        [Required]
        public bool Ricoverato { get; set; }

        [Required]
        public required string DescrizioneAnimale { get; set; }

        [Required]
        public required Guid IdAnimale { get; set; }

        // navigazione

        [ForeignKey(nameof(IdAnimale))]
        public AnagraficaSimpleDTO? AnagraficaAnimale { get; set; }
    }
}
