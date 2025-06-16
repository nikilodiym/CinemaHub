namespace Services.DTOs.Auth;

public class RegisterRequestDto
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
}