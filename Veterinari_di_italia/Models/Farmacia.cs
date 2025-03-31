using System.ComponentModel.DataAnnotations;

namespace Veterinari_di_italia.Models
{
    public class Farmacia
    {
        [Key]
        public Guid IdFarmaco { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string DittaFornitrice { get; set; }

        [Required]
        public string ElencoUsi { get; set; }

        public ICollection<VenditaFarmaco> VenditaFarmaco { get;set; }

    }
}
