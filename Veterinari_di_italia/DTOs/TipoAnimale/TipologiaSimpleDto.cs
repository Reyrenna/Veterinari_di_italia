﻿using System.ComponentModel.DataAnnotations;

namespace Veterinari_di_italia.DTOs.TipoAnimale
{
    public class TipologiaSimpleDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public required string TipoAnimale { get; set; }
    }
}
