namespace DoGiaDung.Application.DTOs;

public record UserRegisterDto(
    string FullName,
    string Email,
    string Password,
    string Phone,
    string? Address
);

public record UserLoginDto(
    string Email,
    string Password
);

public record LoginResponseDto(
    bool Success,
    string? UserName = null,
    string? UserEmail = null,
    string? Error = null
);

public record ForgotPasswordDto(string Email);
public record ResetPasswordDto(string ResetCode, string NewPassword, string ConfirmPassword);
