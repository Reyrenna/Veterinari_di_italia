using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Veterinari_di_italia.Models;
using Veterinari_di_italia.DTOs.TipoAnimale;
using Veterinari_di_italia.DTOs.Account;

namespace Veterinari_di_italia.DTOs.AnagraficaAnimale
{
    public class AnagraficaSimpleDTO
    {
        [Required]
        public DateTime DataRegistrazione { get; set; }

        [Required]
        public required string Nome { get; set; }

        [Required]
        public required int TipologiaId { get; set; }

        [ForeignKey(nameof(TipologiaId))]
        public TipologiaSimpleDto Tipo { get; set; }

        [Required]
        public required string Colore { get; set; }

        [Required]
        public DateOnly DataDiNascita { get; set; }

        [Required]
        public bool PresenzaMicrochip { get; set; }

        public string? NumeroMicroChip { get; set; }

        public string? ProprietarioId { get; set; }

        public UserSimpleDto? ProprietarioAnimale { get; set; }
    }
}
