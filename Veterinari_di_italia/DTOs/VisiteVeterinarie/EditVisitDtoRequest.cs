using System.ComponentModel.DataAnnotations;

namespace Veterinari_di_italia.DTOs.VisiteVeterinarie
{
    public class EditVisitDtoRequest
    {
        [Required]
        public DateTime DataDellaVisita { get; set; }
        [Required]
        public string EsameObiettivo { get; set; }
        [Required]

        public string Descrizione { get; set; }
    }
}
