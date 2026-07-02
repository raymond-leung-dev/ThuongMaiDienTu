using DoGiaDung.Application.Common;
using DoGiaDung.Application.DTOs;
using DoGiaDung.Application.Interfaces;
using DoGiaDung.Domain.Entities;
using DoGiaDung.Domain.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace DoGiaDung.Infrastructure.Services;

public class AuthService : IAuthService
{
    private readonly IRepository<User> _userRepo;
    private readonly IRepository<Admin> _adminRepo;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AuthService(IRepository<User> userRepo, IRepository<Admin> adminRepo, IHttpContextAccessor httpContextAccessor)
    {
        _userRepo = userRepo;
        _adminRepo = adminRepo;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<Result<LoginResponseDto>> LoginAsync(UserLoginDto dto)
    {
        var users = await _userRepo.FindAsync(u => u.UserEmail == dto.Email && u.DelYn == "N");
        var user = users.FirstOrDefault();

        if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
            return Result<LoginResponseDto>.Failure("Correo o contraseña inválidos.", "LOGIN_FAILED");

        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, user.UserName ?? ""),
            new(ClaimTypes.Email, user.UserEmail ?? ""),
            new(ClaimTypes.NameIdentifier, user.UserId.ToString())
        };

        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var principal = new ClaimsPrincipal(identity);

        await _httpContextAccessor.HttpContext!.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            principal,
            new AuthenticationProperties { IsPersistent = true, ExpiresUtc = DateTimeOffset.UtcNow.AddHours(8) });

        return Result<LoginResponseDto>.Success(new LoginResponseDto(
            true, user.UserName, user.UserEmail));
    }

    public async Task<Result> RegisterAsync(UserRegisterDto dto)
    {
        var existing = await _userRepo.FindAsync(u => u.UserEmail == dto.Email);
        if (existing.Any())
            return Result.Failure("Este correo ya está registrado.");

        var user = new User
        {
            UserName = dto.FullName,
            UserEmail = dto.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
            UserPhone = dto.Phone,
            UserAddress = dto.Address,
            DelYn = "N",
            CreatedDt = DateTime.UtcNow
        };

        await _userRepo.AddAsync(user);
        return Result.Ok();
    }

    public async Task<Result> ForgotPasswordAsync(string email)
    {
        var users = await _userRepo.FindAsync(u => u.UserEmail == email);
        var user = users.FirstOrDefault();
        if (user == null)
            return Result.Failure("No se encontró una cuenta con este correo.");

        user.ResetPasswordCode = Guid.NewGuid().ToString();
        await _userRepo.UpdateAsync(user);

        // TODO: send email via IEmailService
        return Result.Ok();
    }

    public async Task<Result> ResetPasswordAsync(ResetPasswordDto dto)
    {
        var users = await _userRepo.FindAsync(u => u.ResetPasswordCode == dto.ResetCode);
        var user = users.FirstOrDefault();
        if (user == null)
            return Result.Failure("Enlace de restablecimiento inválido o expirado.");

        user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.NewPassword);
        user.ResetPasswordCode = null;
        await _userRepo.UpdateAsync(user);
        return Result.Ok();
    }

    public Task LogoutAsync()
    {
        _httpContextAccessor.HttpContext!.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return Task.CompletedTask;
    }

    // --- Admin Login ---
    public async Task<Result<LoginResponseDto>> AdminLoginAsync(string username, string password)
    {
        var admins = await _adminRepo.FindAsync(a => a.Username == username && a.DelYn == "N");
        var admin = admins.FirstOrDefault();
        if (admin == null)
            return Result<LoginResponseDto>.Failure("Invalid credentials.", "LOGIN_FAILED");

        // Check BCrypt hash first, then fallback to plaintext (legacy data)
        bool ok;
        try
        {
            ok = BCrypt.Net.BCrypt.Verify(password, admin.PasswordHash);
        }
        catch
        {
            ok = (admin.PasswordHash == password); // legacy plaintext
        }

        if (!ok)
        {
            // Try direct comparison for legacy plaintext passwords
            if (admin.PasswordHash == password)
            {
                // Auto-upgrade to BCrypt
                admin.PasswordHash = BCrypt.Net.BCrypt.HashPassword(password);
                await _adminRepo.UpdateAsync(admin);
                ok = true;
            }
        }

        if (!ok)
            return Result<LoginResponseDto>.Failure("Invalid credentials.", "LOGIN_FAILED");

        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, admin.Username),
            new(ClaimTypes.NameIdentifier, admin.AdminId.ToString()),
            new(ClaimTypes.Role, "Admin")
        };

        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var principal = new ClaimsPrincipal(identity);

        await _httpContextAccessor.HttpContext!.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            principal,
            new AuthenticationProperties { IsPersistent = true, ExpiresUtc = DateTimeOffset.UtcNow.AddHours(8) });

        return Result<LoginResponseDto>.Success(new LoginResponseDto(true, admin.Username, null));
    }
}
