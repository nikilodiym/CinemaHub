using Microsoft.AspNetCore.Mvc;
using Services.Implementations;
using CinemaServer.DTOs.Auth;
using Microsoft.Extensions.Configuration;
using Services.Interfaces;

namespace CinemaServer.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly JwtTokenService _jwtTokenService;
    private readonly IAuthService _authService;

    public AuthController(IConfiguration configuration, JwtTokenService jwtTokenService, IAuthService authService)
    {
        _configuration = configuration;
        _jwtTokenService = jwtTokenService;
        _authService = authService;
    }
    

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequestDto request)
    {
        var result = await _authService.RegisterAsync(request.Username, request.Password, request.Email);
        if (!result)
            return BadRequest(new RegisterResponseDto { Success = false, Error = "User already exists" });
        var token = _jwtTokenService.GenerateJwtToken(request.Username, request.Email);
        return Ok(new RegisterResponseDto { Success = true, Token = token });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
    {
        var userId = await _authService.LoginAsync(request.Username, request.Password);
        if (userId == null)
            return Unauthorized();
        var token = _jwtTokenService.GenerateJwtToken(request.Username, "");
        return Ok(new LoginResponseDto { Success = true, Token = token });
    }
}
