using System.ComponentModel.DataAnnotations;

namespace Auth.Models.User.DTO
{
    public class RegisterDTO
    {
        [Required]
        [MinLength(2)]
        public string Username { get; set; } = null!;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        [MinLength(8)]
        [Required]
        public string Password { get; set; } = null!;
        [Required]
        [MinLength(8)]
        public string ConfirmPassword { get; set; } = null!;
    }
}
