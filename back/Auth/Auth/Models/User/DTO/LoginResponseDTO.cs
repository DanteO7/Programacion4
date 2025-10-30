namespace Auth.Models.User.DTO
{
    public class LoginResponseDTO
    {
        public string Token { get; set; } = null!;
        public UserWithoutPassDTO User = null!;
    }
}
