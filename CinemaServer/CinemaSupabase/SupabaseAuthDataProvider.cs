using System.Threading.Tasks;
using Services.Interfaces;
using CinemaServer.CinemaSupabase;
using CinemaServer.Models;
using Postgrest;

namespace CinemaServer.CinemaSupabase;

public class SupabaseAuthDataProvider : IAuthDataProvider
{
    private readonly SupabaseClient.SupabaseService _supabaseService;

    public SupabaseAuthDataProvider()
    {
        _supabaseService = new SupabaseClient.SupabaseService();
    }

    public async Task<bool> UserExistsAsync(string username)
    {
        var users = await _supabaseService.supabaseClient.From<User>().Filter(x => x.UserName, Operator.Equals, username).Get();
        return users.Models.Count > 0;
    }

    public async Task<bool> CreateUserAsync(string username, string passwordHash, string email)
    {
        var user = new User { UserName = username, UserPassword_hash = passwordHash, Email = email };
        var response = await _supabaseService.supabaseClient.From<User>().Insert(user);
        return response.ResponseMessage != null && response.ResponseMessage.IsSuccessStatusCode;
    }

    public async Task<AuthUserDto?> GetUserByUsernameAsync(string username)
    {
        var users = await _supabaseService.supabaseClient.From<User>().Filter(x => x.UserName, Operator.Equals, username).Get();
        if (users.Models.Count == 0)
            return null;
        var user = users.Models[0];
        return new AuthUserDto
        {
            UserId = user.UserId.ToString(),
            PasswordHash = user.UserPassword_hash
        };
    }
}

