﻿using System.ComponentModel.DataAnnotations;

namespace Veterinari_di_italia.DTOs.GestioneRicoveri
{
    public class DeleteGestioneRicoveriResponseDto
    {
        [Required]
        public required string Message { get; set; }
    }
}
