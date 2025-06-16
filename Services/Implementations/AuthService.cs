using Core.Helpers;
using Services.Interfaces;
using Supabase.Gotrue;
using System.Threading.Tasks;

namespace Services.Implementations;

public class AuthService : IAuthService
{
    private readonly IAuthDataProvider _authDataProvider;
    private readonly PasswordHasher _passwordHasher;

    public AuthService(IAuthDataProvider authDataProvider)
    {
        _authDataProvider = authDataProvider;
        _passwordHasher = new PasswordHasher();
    }

    public async Task<bool> RegisterAsync(string username, string password, string email)
    {
        if (await _authDataProvider.UserExistsAsync(username))
            return false;
        var passwordHash = _passwordHasher.HashPassword(password);
        return await _authDataProvider.CreateUserAsync(username, passwordHash, email);
    }

    public async Task<string?> LoginAsync(string username, string password)
    {
        var user = await _authDataProvider.GetUserByUsernameAsync(username);
        if (user == null)
            return null;
        if (!_passwordHasher.VerifyPassword(password, user.PasswordHash))
            return null;
        return user.UserId;
    }
}

