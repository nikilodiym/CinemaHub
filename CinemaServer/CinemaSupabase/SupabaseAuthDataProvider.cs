using System.Threading.Tasks;
using Services.Interfaces;
using CinemaServer.CinemaSupabase;
using CinemaServer.Models;
using CinemaWPF.Core.Models;
using Supabase.Postgrest;

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
        var users = await _supabaseService.supabaseClient.From<User>().Filter(x => x.UserName, Constants.Operator.Equals, username).Get();
        return users.Models.Count > 0;
    }
    
    public async Task<bool> AddFilmAsync(Movie movie)
    {
        try
        {
            var response = await _supabaseService.supabaseClient.From<Movie>().Insert(movie);
            if (response.ResponseMessage != null && response.ResponseMessage.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                var errorContent = await response.ResponseMessage.Content.ReadAsStringAsync();
                Console.WriteLine($"Error: {errorContent}");
                return false;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception: {ex.Message}");
            throw;
        }
    }

    public async Task<bool> CreateUserAsync(string username, string passwordHash, string email)
    {
        var user = new User { UserName = username, UserPasswordHash = passwordHash, Email = email };
        var response = await _supabaseService.supabaseClient.From<User>().Insert(user);
        return response.ResponseMessage != null && response.ResponseMessage.IsSuccessStatusCode;
    }

    public async Task<AuthUserDto?> GetUserByUsernameAsync(string username)
    {
        var users = await _supabaseService.supabaseClient.From<User>().Filter(x => x.UserName, Constants.Operator.Equals, username).Get();
        if (users.Models.Count == 0)
            return null;
        var user = users.Models[0];
        return new AuthUserDto
        {
            UserId = user.UserId.ToString(),
            PasswordHash = user.UserPasswordHash
        };
    }

    public async Task<List<Movie>> GetAllFilmsAsync()
    {
        var response = await _supabaseService.supabaseClient.From<Movie>().Get();
        return response.Models;
    }
}
