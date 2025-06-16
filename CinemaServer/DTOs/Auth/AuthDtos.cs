namespace CinemaServer.DTOs.Auth;

public class RegisterRequestDto
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
}

public class RegisterResponseDto
{
    public bool Success { get; set; }
    public string Token { get; set; }
    public string Error { get; set; }
}

public class LoginRequestDto
{
    public string Username { get; set; }
    public string Password { get; set; }
}

public class LoginResponseDto
{
    public bool Success { get; set; }
    public string Token { get; set; }
    public string Error { get; set; }
}

