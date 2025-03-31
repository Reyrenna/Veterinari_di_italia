using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Veterinari_di_italia.Models
{
    public class AnagraficaAnimale
    {
        [Key]
        public Guid IdAnimale { get; set; }
        [Required]
        public DateTime DataRegistrazione { get; set; }
        [Required]
        [MaxLength(80)]
        public required string Nome {  get; set; }
        [Required]
        
        public TipologiaAnimale Tipo {  get; set; } 

        [Required]
        public required string Colore { get; set; }
        [Required]
        public DateOnly DataDiNascita { get; set; }
        [Required]
        public bool PresenzaMicrochip { get; set; }

        public string? NumeroMicroChip { get; set; }

        public ApplicationUser? ProprietarioAnimale { get; set; }

        public ICollection<VisiteVeterinarie> visiteVeterinaries { get; set; }

        public ICollection<GestioneRicoveri> gestioneRicoveris { get; set; } 
  
             
    }
}
