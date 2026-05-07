using BartenderHelper.Api.Data;
using BartenderHelper.Api.DTOs;
using BartenderHelper.Api.Models;
using BartenderHelper.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace BartenderHelper.Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _db;
    private readonly TokenService _tokenService;

    public AuthController(AppDbContext db, TokenService tokenService)
    {
        _db = db;
        _tokenService = tokenService;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        if (_db.Users.Any(u => u.Username == request.Username))
            return BadRequest("Username is already taken.");

        var user = new User
        {
            Username = request.Username,
            Email = request.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password)
        };

        _db.Users.Add(user);
        _db.SaveChanges();

        var token = _tokenService.CreateToken(user);
        return Ok(new AuthResponse(user.Username, token));
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var user = _db.Users.SingleOrDefault(u => u.Username == request.Username);

        if (user is null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            return Unauthorized("Invalid username or password.");

        var token = _tokenService.CreateToken(user);
        return Ok(new AuthResponse(user.Username, token));
    }
}
