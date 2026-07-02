using DoGiaDung.Application.DTOs;
using DoGiaDung.Application.Interfaces;
using DoGiaDung.Domain.Entities;
using DoGiaDung.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DoGiaDung.Web.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize]
public class UserController : Controller
{
    private readonly IRepository<Domain.Entities.User> _repo;
    public UserController(IRepository<Domain.Entities.User> repo) => _repo = repo;

    public async Task<IActionResult> Index(string? name)
    {
        if (string.IsNullOrEmpty(name))
            return View(await _repo.GetAllAsync());
        var users = await _repo.FindAsync(u => u.UserName!.Contains(name));
        return View(users);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var user = await _repo.GetByIdAsync(id);
        if (user == null) return NotFound();
        return View(user);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, Domain.Entities.User user)
    {
        user.UserId = id;
        await _repo.UpdateAsync(user);
        return RedirectToAction(nameof(Index));
    }
}
