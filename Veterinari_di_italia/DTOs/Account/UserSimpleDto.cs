using System.ComponentModel.DataAnnotations;

namespace Veterinari_di_italia.DTOs.Account
{
    public class UserSimpleDto
    {
        [Required]
        public required string Id { get; set; }

        [Required]
        public required string Nome { get; set; }

        [Required]
        public required string Cognome { get; set; }

        [Required]
        public required string CodiceFiscale { get; set; }

        [Required]
        public required string Email { get; set; }
    }
}
