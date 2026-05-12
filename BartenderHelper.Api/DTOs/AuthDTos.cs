namespace BartenderHelper.Api.DTOs;

public record RegisterRequest(string Username, string Email, string Password);

public record LoginRequest(string Username, string Password);

public record AuthResponse(string Username, string Token);
public record ChangePasswordRequest(string CurrentPassword, string NewPassword);
public record ChangeUsernameRequest(string NewUsername);
public record ChangeEmailRequest(string NewEmail);

