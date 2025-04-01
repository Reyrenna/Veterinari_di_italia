using System.ComponentModel.DataAnnotations;
using Veterinari_di_italia.DTOs.AnagraficaAnimale;

namespace Veterinari_di_italia.DTOs.TipoAnimale
{
    public class GetTipoAnimaleRequestDTO
    {
        [Required]

        public string TipoAnimale { get; set; }

        [Required]

        public ICollection<AnagraficaSimpleDTO> AnagraficaAnimale { get; set; }
    }
}
