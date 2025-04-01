using System.ComponentModel.DataAnnotations;
using Veterinari_di_italia.DTOs.AnagraficaAnimale;

namespace Veterinari_di_italia.DTOs.TipoAnimale
{
    public class TipologiaICollection
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public required string TipoAnimale { get; set; }

        [Required]
        public ICollection<AnagraficaSimpleDTO> Anagrafiche { get; set; }
    }
}
