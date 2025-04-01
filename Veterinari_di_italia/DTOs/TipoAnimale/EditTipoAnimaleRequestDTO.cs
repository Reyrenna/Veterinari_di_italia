using System.ComponentModel.DataAnnotations;

namespace Veterinari_di_italia.DTOs.TipoAnimale
{
    public class EditTipoAnimaleRequestDTO
    {
        [Required]
        public string TipoAnimale { get; set; }
    }
}
