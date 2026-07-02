using Microsoft.AspNetCore.Mvc;

namespace DoGiaDung.Web.Controllers;

/// <summary>
/// Endpoint để đổi ngôn ngữ. Cookie-based, không cần Session.
/// </summary>
public class LangController : Controller
{
    [HttpPost]
    public IActionResult Set(string lang, string? returnUrl)
    {
        var cookieOptions = new CookieOptions
        {
            Expires = DateTimeOffset.UtcNow.AddYears(1),
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.Lax,
            Path = "/"
        };
        Response.Cookies.Append("lang", lang, cookieOptions);
        return LocalRedirect(returnUrl ?? "/");
    }
}
