using System.ComponentModel.DataAnnotations;
using Veterinari_di_italia.DTOs.AnagraficaAnimale;
using Veterinari_di_italia.DTOs.Farmacia;
using Veterinari_di_italia.DTOs.FarmaciaVisiteVeterinarie;
using Veterinari_di_italia.Models;

namespace Veterinari_di_italia.DTOs.VisiteVeterinarie
{
    public class VisiteVeterinarieSimpleDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public DateTime DataDellaVisita { get; set; }

        [Required]
        public required string EsameObiettivo { get; set; }

        [Required]
        public required string Descrizione { get; set; }

        public List<GetFarmaciFarmaciaVisiteVeterinarieDto>? FarmaciVisiteVeterinarie { get; set; }

        public AnagraficaSimpleDTO Anagrafica { get; set; }
    }
}
