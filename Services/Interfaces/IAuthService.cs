namespace Services.Interfaces;

using System.Threading.Tasks;

public interface IAuthService
{
    Task<bool> RegisterAsync(string username, string password, string email);
    Task<string?> LoginAsync(string username, string password);
}

