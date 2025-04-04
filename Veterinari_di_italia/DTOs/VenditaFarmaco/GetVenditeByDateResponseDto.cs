﻿using System.ComponentModel.DataAnnotations;

namespace Veterinari_di_italia.DTOs.VenditaFarmaco
{
    public class GetVenditeByDateResponseDto
    {

        [Required]
        public required string Message { get; set; }

        [Required]

        public required List<VenditaFarmacoDto>? Vendite { get; set; }

    }
}
