using DoGiaDung.Domain.Entities;
using DoGiaDung.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DoGiaDung.Web.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize]
public class FeedbackController : Controller
{
    private readonly IRepository<Feedback> _repo;
    public FeedbackController(IRepository<Feedback> repo) => _repo = repo;

    public async Task<IActionResult> Index()
    {
        return View(await _repo.GetAllAsync());
    }
}
