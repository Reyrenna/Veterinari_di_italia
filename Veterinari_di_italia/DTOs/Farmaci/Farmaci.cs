using System.ComponentModel.DataAnnotations;

namespace Veterinari_di_italia.DTOs.Farmaci
{
    public class Farmaci
    {
        [Required]
        public Guid IdFarmaco { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string DittaFornitrice { get; set; }
        [Required]
        public string ElencoUsi { get; set; }

    }
}
