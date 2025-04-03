using System.ComponentModel.DataAnnotations;
using Veterinari_di_italia.DTOs.Farmacia;

namespace Veterinari_di_italia.DTOs.VenditaFarmaco
{
    public class GetListaFarmaciByFiscalCodeResponseDto
    {
        [Required]
        public required string Message { get; set; }

        [Required]
        public string? FiscalCode { get; set; }

        [Required]
        public required List<FarmaciaSimpleDto>? Farmaci { get; set; }
    }
}
