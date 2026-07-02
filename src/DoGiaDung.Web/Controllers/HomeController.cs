using Microsoft.AspNetCore.Mvc;

namespace DoGiaDung.Web.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        ViewBag.Message = "Bienvenido a DoGiaDung";
        return View();
    }

    public IActionResult About()
    {
        ViewBag.Message = "Sobre nosotros";
        return View();
    }

    public IActionResult Contact()
    {
        ViewBag.Message = "Contacto";
        return View();
    }

    public IActionResult Error() => View();
}
