using DoGiaDung.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DoGiaDung.Web.Areas.Admin.Controllers;

[Area("Admin")]
public class AdminController : Controller
{
    private readonly DoGiaDung.Application.Interfaces.IAuthService _auth;

    public AdminController(IAuthService auth) => _auth = auth;

    public IActionResult Index() => View();

    [HttpPost]
    public async Task<IActionResult> Login(string username, string password)
    {
        var result = await _auth.AdminLoginAsync(username, password);
        if (!result.IsSuccess)
        {
            ViewBag.ErrorInfo = result.Error;
            return View("Index");
        }
        return RedirectToAction("Index", "Home", new { area = "Admin" });
    }

    public async Task<IActionResult> Logout()
    {
        await _auth.LogoutAsync();
        return RedirectToAction("Index");
    }
}
