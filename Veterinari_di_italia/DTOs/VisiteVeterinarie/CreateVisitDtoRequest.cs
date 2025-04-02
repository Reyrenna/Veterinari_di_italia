using System.ComponentModel.DataAnnotations;
using Veterinari_di_italia.DTOs.FarmaciaVisiteVeterinarie;

namespace Veterinari_di_italia.DTOs.VisiteVeterinarie
{
    public class CreateVisitDtoRequest
    {
        [Required]
        public DateTime DataDellaVisita { get; set; }

        [Required]
        public required string EsameObiettivo { get; set; }

        [Required]
        public required string Descrizione { get; set; }

        [Required]
        public string IdAnagraficaAnimale { get; set; }

        public List<CreateFarmaciaVisiteVeterinarieByVisitaRequestDto>? Farmaci { get; set; }
    }
}
