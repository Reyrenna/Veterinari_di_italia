using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Veterinari_di_italia.Models
{
    public class TipologiaAnimale
    {
        [Key]
        public int Id { get; set; }

        public string TipoAnimale { get; set; }

        public ICollection<AnagraficaAnimale> AnagraficaAnimale { get; set;}

    }
}
