using DoGiaDung.Application.Interfaces;
using DoGiaDung.Domain.Entities;
using DoGiaDung.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DoGiaDung.Web.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize]
public class CatalogController : Controller
{
    private readonly IRepository<Catalog> _repo;
    public CatalogController(IRepository<Catalog> repo) => _repo = repo;

    public async Task<IActionResult> Index()
    {
        var items = await _repo.GetAllAsync();
        return View(items);
    }

    public IActionResult Create() => View();

    [HttpPost]
    public async Task<IActionResult> Create(Catalog catalog)
    {
        await _repo.AddAsync(catalog);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var item = await _repo.GetByIdAsync(id);
        if (item == null) return NotFound();
        return View(item);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, Catalog catalog)
    {
        catalog.CatalogId = id;
        await _repo.UpdateAsync(catalog);
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
