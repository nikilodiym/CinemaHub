using Microsoft.AspNetCore.Mvc;
using Services.DTOs.Auth;
using Microsoft.Extensions.Configuration;
using Services.Interfaces;

namespace CinemaServer.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequestDto request)
    {
        var result = await _authService.RegisterAsync(request.Username, request.Password, request.Email);
        if (!result)
            return BadRequest(new RegisterResponseDto { Success = false, Error = "User already exists" });
        return Ok(new RegisterResponseDto { Success = true });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
    {
        var userId = await _authService.LoginAsync(request.Username, request.Password);
        if (userId == null)
            return Unauthorized();
        return Ok(new LoginResponseDto { Success = true });
    }
}
