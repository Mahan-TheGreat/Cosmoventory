using System.ComponentModel.DataAnnotations;

namespace Cosmoventory.DTO
{
    public class LoginRequestDTO
    {
        [Required]
        public string Username { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;
    }
}
