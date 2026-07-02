using DoGiaDung.Application.Common;
using DoGiaDung.Application.DTOs;

namespace DoGiaDung.Application.Interfaces;

public interface IAuthService
{
    Task<Result<LoginResponseDto>> LoginAsync(UserLoginDto dto);
    Task<Result> RegisterAsync(UserRegisterDto dto);
    Task<Result> ForgotPasswordAsync(string email);
    Task<Result> ResetPasswordAsync(ResetPasswordDto dto);
    Task LogoutAsync();
    Task<Result<LoginResponseDto>> AdminLoginAsync(string username, string password);
}
