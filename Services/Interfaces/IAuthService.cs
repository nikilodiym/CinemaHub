namespace Services.Interfaces;

public interface IAuthService
{
    bool Register(string username, string password, string email);
    string Login(string username, string password);
}