using DoGiaDung.Domain.Entities;
using DoGiaDung.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DoGiaDung.Web.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize]
public class SlideController : Controller
{
    private readonly IRepository<Slide> _repo;
    public SlideController(IRepository<Slide> repo) => _repo = repo;

    public async Task<IActionResult> Index()
    {
        return View(await _repo.GetAllAsync());
    }

    public IActionResult Create() => View();

    [HttpPost]
    public async Task<IActionResult> Create(Slide slide)
    {
        await _repo.AddAsync(slide);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        var item = await _repo.GetByIdAsync(id);
        if (item != null) { item.DelYn = "Y"; await _repo.UpdateAsync(item); }
        return RedirectToAction(nameof(Index));
    }
}
