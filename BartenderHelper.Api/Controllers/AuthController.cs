using BartenderHelper.Api.Data;
using BartenderHelper.Api.DTOs;
using BartenderHelper.Api.Models;
using BartenderHelper.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

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

    [Authorize]
    [HttpPut("password")]
    public IActionResult ChangePassword(ChangePasswordRequest request)
    {
        var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var user = _db.Users.Find(userId);
        if (user is null) return NotFound();

        if (!BCrypt.Net.BCrypt.Verify(request.CurrentPassword, user.PasswordHash))
            return BadRequest("Current password is incorrect.");

        user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.NewPassword);
        _db.SaveChanges();
        return NoContent();
    }

    [Authorize]
    [HttpPut("username")]
    public IActionResult ChangeUsername(ChangeUsernameRequest request)
    {
        var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        if (_db.Users.Any(u => u.Username == request.NewUsername && u.Id != userId))
            return BadRequest("Username is already taken.");

        var user = _db.Users.Find(userId);
        if (user is null) return NotFound();

        user.Username = request.NewUsername;
        _db.SaveChanges();

        var token = _tokenService.CreateToken(user);
        return Ok(new AuthResponse(user.Username, token));
    }

    [Authorize]
    [HttpPut("email")]
    public IActionResult ChangeEmail(ChangeEmailRequest request)
    {
        var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        if (_db.Users.Any(u => u.Email == request.NewEmail && u.Id != userId))
            return BadRequest("Email is already in use.");

        var user = _db.Users.Find(userId);
        if (user is null) return NotFound();

        user.Email = request.NewEmail;
        _db.SaveChanges();
        return NoContent();
    }

    [Authorize]
    [HttpGet("me")]
    public IActionResult GetMe()
    {
        var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var user = _db.Users.Find(userId);
        if (user is null) return NotFound();
        return Ok(new { user.Username, user.Email });
    }

}
