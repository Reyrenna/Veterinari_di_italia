using System.ComponentModel.DataAnnotations;

namespace Veterinari_di_italia.DTOs.GestioneRicoveri
{
    public class GestioneRicoveriSimpleDto
    {
        [Required]
        public int IdRicovero { get; set; }

        [Required]
        public DateTime DataRicovero { get; set; }

        [Required]
        public bool Ricoverato { get; set; }

        [Required]
        public required string DescrizioneAnimale { get; set; }
    }
}
