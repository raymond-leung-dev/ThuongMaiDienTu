using DoGiaDung.Domain.Entities;
using DoGiaDung.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DoGiaDung.Web.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize]
public class TagController : Controller
{
    private readonly IRepository<Tag> _repo;
    public TagController(IRepository<Tag> repo) => _repo = repo;

    public async Task<IActionResult> Index()
    {
        return View(await _repo.GetAllAsync());
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        var item = await _repo.GetByIdAsync(id);
        if (item != null) { item.DelYn = "Y"; await _repo.UpdateAsync(item); }
        return RedirectToAction(nameof(Index));
    }
}
