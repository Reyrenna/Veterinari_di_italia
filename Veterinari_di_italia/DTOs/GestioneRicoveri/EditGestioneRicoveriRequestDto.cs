using System.ComponentModel.DataAnnotations;

namespace Veterinari_di_italia.DTOs.GestioneRicoveri
{
    public class EditGestioneRicoveriRequestDto
    {
        [Required]
        public DateTime DataRicovero { get; set; }

        [Required]
        public bool Ricoverato { get; set; }

        [Required]
        public required string DescrizioneAnimale { get; set; }

        [Required]
        public required Guid IdAnimale { get; set; }
    }
}
