using System.ComponentModel.DataAnnotations;

namespace Veterinari_di_italia.DTOs.Account
{
    public class CreateUserDto
    {
        [Required]
        public required string Nome { get; set; }

        [Required]
        public required string Cognome { get; set; }

        [Required]
        //[EmailAddress]
        public required string Email { get; set; }

        //[Required]
        //[Phone]
        public required string Telefono { get; set; }

        [Required]
        //[StringLength(16)]
        public required string CodiceFiscale { get; set; }

        [Required]
        public required string Password { get; set; }
    }
}
