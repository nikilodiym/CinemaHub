namespace Services.Implementations;

public class AuthService
{
    public bool Register(string username, string password, string email)
    {
        return true; 
    }

    public string Login(string username, string password)
    {
        return "token"; 
    }
}