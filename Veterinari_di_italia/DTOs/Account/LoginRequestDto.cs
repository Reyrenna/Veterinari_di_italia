using System.ComponentModel.DataAnnotations;

namespace Veterinari_di_italia.DTOs.Account
{
    public class LoginRequestDto
    {
        [Required]
        public required string Email { get; set; }

        [Required]
        public required string Password { get; set; }
    }
}
