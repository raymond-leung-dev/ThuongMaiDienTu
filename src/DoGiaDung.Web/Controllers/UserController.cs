using DoGiaDung.Application.DTOs;
using DoGiaDung.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DoGiaDung.Web.Controllers;

public class UserController : Controller
{
    private readonly IAuthService _authService;

    public UserController(IAuthService authService) => _authService = authService;

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
}
