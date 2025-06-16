namespace Services.Interfaces;

public interface IAuthDataProvider
{
    Task<bool> UserExistsAsync(string username);
    Task<bool> CreateUserAsync(string username, string passwordHash, string email);
    Task<AuthUserDto?> GetUserByUsernameAsync(string username);
}

public class AuthUserDto
{
    public string UserId { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
}
