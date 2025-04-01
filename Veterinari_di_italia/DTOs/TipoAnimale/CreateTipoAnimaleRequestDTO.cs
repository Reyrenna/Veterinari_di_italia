using System.ComponentModel.DataAnnotations;
using Veterinari_di_italia.Models;

namespace Veterinari_di_italia.DTOs.TipoAnimale
{
    public class CreateTipoAnimaleRequestDTO
    {
        [Required]
        public string TipoAnimale { get; set; }
    }
}
