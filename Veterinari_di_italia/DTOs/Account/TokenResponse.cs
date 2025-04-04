using System.ComponentModel.DataAnnotations;

namespace Veterinari_di_italia.DTOs.Account
{
    public class TokenResponse
    {
        [Required]
        public required string Token { get; set; }

        [Required]
        public required DateTime Expires { get; set; }
    }
}
