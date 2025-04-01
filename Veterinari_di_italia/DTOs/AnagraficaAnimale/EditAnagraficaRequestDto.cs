using System.ComponentModel.DataAnnotations;

namespace Veterinari_di_italia.DTOs.AnagraficaAnimale
{
    public class EditAnagraficaRequestDto
    {
        [Required]
        public DateTime DataRegistrazione { get; set; }

        [Required]
        public required string Nome { get; set; }

        [Required]
        public required string Colore { get; set; }

        [Required]
        public DateOnly DataDiNascita { get; set; }

        [Required]
        public required bool PresenzaMicrochip { get; set; }

        public string? NumeroMicrochip { get; set; }

        public string? ProprietarioId { get; set; }

        [Required]
        public required int TipologiaId { get; set; }
    }
}
