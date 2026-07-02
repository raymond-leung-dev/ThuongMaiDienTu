using DoGiaDung.Application.DTOs;
using DoGiaDung.Application.Interfaces;
using DoGiaDung.Domain.Entities;
using DoGiaDung.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DoGiaDung.Web.Controllers;

public class UserController : Controller
{
    private readonly IAuthService _authService;
    private readonly IRepository<User> _userRepo;
    private readonly IOrderService _orderService;

    public UserController(IAuthService authService, IRepository<User> userRepo, IOrderService orderService)
    {
        _authService = authService;
        _userRepo = userRepo;
        _orderService = orderService;
    }

    // --- Login / Register / Logout ---
    public IActionResult Index() => View();

    [HttpPost]
    public async Task<IActionResult> Login(UserLoginDto dto)
    {
        var result = await _authService.LoginAsync(dto);
        if (!result.IsSuccess)
        {
            ViewBag.Error = result.Error;
            return View("Index");
        }
        return RedirectToAction("Index", "Home");
    }

    public IActionResult Register() => View();

    [HttpPost]
    public async Task<IActionResult> Register(UserRegisterDto dto)
    {
        var result = await _authService.RegisterAsync(dto);
        if (!result.IsSuccess)
        {
            ViewBag.Error = result.Error;
            return View();
        }
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Logout()
    {
        await _authService.LogoutAsync();
        return RedirectToAction("Index", "Home");
    }

    // --- Profile ---
    [Authorize]
    public async Task<IActionResult> ThongTin()
    {
        var email = User.FindFirst(System.Security.Claims.ClaimTypes.Email)?.Value;
        var users = await _userRepo.FindAsync(u => u.UserEmail == email);
        var user = users.FirstOrDefault();
        if (user == null) return NotFound();
        return View(user);
    }

    [Authorize]
    public async Task<IActionResult> EditUser(int id)
    {
        var user = await _userRepo.GetByIdAsync(id);
        if (user == null) return NotFound();
        return View(user);
    }

    [HttpPost, Authorize]
    public async Task<IActionResult> EditUser(int id, User user)
    {
        user.UserId = id;
        await _userRepo.UpdateAsync(user);
        return RedirectToAction(nameof(ThongTin));
    }

    // --- Forgot / Reset Password ---
    public IActionResult ForgotPassword() => View();

    [HttpPost]
    public async Task<IActionResult> ForgotPassWord(string emailId)
    {
        var result = await _authService.ForgotPasswordAsync(emailId);
        ViewBag.Message = result.IsSuccess ? "Se ha enviado un correo." : result.Error;
        return View("ForgotPassword");
    }

    public IActionResult ResetPassword(string id)
    {
        if (string.IsNullOrWhiteSpace(id)) return NotFound();
        return View(new ResetPasswordDto(id, "", ""));
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> ResetPassword(ResetPasswordDto model)
    {
        if (!ModelState.IsValid) return View(model);
        var result = await _authService.ResetPasswordAsync(model);
        ViewBag.Message = result.IsSuccess ? "Contraseña actualizada." : result.Error;
        return View(model);
    }

    // --- Orders ---
    [Authorize]
    public async Task<IActionResult> History(int? page)
    {
        var email = User.FindFirst(System.Security.Claims.ClaimTypes.Email)?.Value ?? "";
        var result = await _orderService.GetUserOrdersAsync(email, page ?? 1, 10);
        return View(result.Data);
    }

    [Authorize]
    public async Task<IActionResult> DetailHis(int id)
    {
        var result = await _orderService.GetByIdAsync(id);
        if (!result.IsSuccess) return NotFound();
        return View();
    }

    [Authorize]
    public async Task<IActionResult> YeuCauHuyDon(int id)
    {
        var email = User.FindFirst(System.Security.Claims.ClaimTypes.Email)?.Value ?? "";
        await _orderService.CancelOrderAsync(id, email);
        return RedirectToAction(nameof(History));
    }
}
