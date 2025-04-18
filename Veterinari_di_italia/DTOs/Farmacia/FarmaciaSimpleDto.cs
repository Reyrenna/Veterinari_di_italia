﻿using System.ComponentModel.DataAnnotations;
using Veterinari_di_italia.DTOs.FarmaciaVenditaFarmaco;
using Veterinari_di_italia.DTOs.VenditaFarmaco;
using Veterinari_di_italia.Models;

namespace Veterinari_di_italia.DTOs.Farmacia
{
    public class FarmaciaSimpleDto
    {
        [Key]
        public Guid IdFarmaco { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string DittaFornitrice { get; set; }

        [Required]
        public string ElencoUsi { get; set; }

        [Required]
        public required bool Farmaco { get; set; }

        public List<GetFarmacoFarmaciaVenditaFarmacoResponseDto>? FarmaciaVenditaFarmaco { get; set; }
    }
}
