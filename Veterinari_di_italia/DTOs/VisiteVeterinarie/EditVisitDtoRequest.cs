using System.ComponentModel.DataAnnotations;
using Veterinari_di_italia.DTOs.AnagraficaAnimale;
using Veterinari_di_italia.DTOs.FarmaciaVenditaFarmaco;

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

        [Required]
        
        public required Guid IdAnagraficaAnimale { get; set; }

        [Required]

        public List<CreateVenditaFarmaciaVenditaFarmacoDto>? Farmaco { get; set; }
    }
}
