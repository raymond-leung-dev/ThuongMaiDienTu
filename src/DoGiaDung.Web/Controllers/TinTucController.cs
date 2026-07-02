using DoGiaDung.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DoGiaDung.Web.Controllers;

public class TinTucController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Details(int id)
    {
        return View();
    }
}
