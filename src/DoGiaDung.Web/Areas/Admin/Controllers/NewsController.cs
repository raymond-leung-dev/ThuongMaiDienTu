using DoGiaDung.Domain.Entities;
using DoGiaDung.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DoGiaDung.Web.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize]
public class NewsController : Controller
{
    private readonly IRepository<News> _repo;
    public NewsController(IRepository<News> repo) => _repo = repo;

    public async Task<IActionResult> Index()
    {
        return View(await _repo.GetAllAsync());
    }

    public IActionResult Create() => View();

    [HttpPost]
    public async Task<IActionResult> Create(News news)
    {
        await _repo.AddAsync(news);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var item = await _repo.GetByIdAsync(id);
        if (item == null) return NotFound();
        return View(item);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, News news)
    {
        news.NewsId = id;
        await _repo.UpdateAsync(news);
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
