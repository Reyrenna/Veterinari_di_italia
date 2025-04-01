using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Veterinari_di_italia.Models;

namespace Veterinari_di_italia.DTOs.AnagraficaAnimale
{
    public class AnagraficaDto
    {
        [Required]
        public Guid IdAnimale { get; set; }

        [Required]
        public DateTime DataRegistrazione { get; set; }

        [Required]
        public required string Nome { get; set; }

        [Required]
        public required int TipologiaId { get; set; }

        [ForeignKey(nameof(TipologiaId))]
        public TipologiaAnimale Tipo { get; set; }

        [Required]
        public required string Colore { get; set; }

        [Required]
        public DateOnly DataDiNascita { get; set; }

        [Required]
        public bool PresenzaMicrochip { get; set; }

        public string? NumeroMicroChip { get; set; }

        public string? ProprietarioId { get; set; }

        public ApplicationUser? ProprietarioAnimale { get; set; }

        public ICollection<VisiteVeterinarie> visiteVeterinaries { get; set; }

        public ICollection<GestioneRicoveri> gestioneRicoveris { get; set; }
    }
}
