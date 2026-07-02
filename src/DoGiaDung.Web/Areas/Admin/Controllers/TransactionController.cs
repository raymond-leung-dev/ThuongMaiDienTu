using DoGiaDung.Application.Interfaces;
using DoGiaDung.Domain.Entities;
using DoGiaDung.Domain.Enums;
using DoGiaDung.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoGiaDung.Web.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize]
public class TransactionController : Controller
{
    private readonly IRepository<Transaction> _repo;
    public TransactionController(IRepository<Transaction> repo) => _repo = repo;

    public async Task<IActionResult> Index(string? status)
    {
        var query = _repo.Query();
        if (!string.IsNullOrEmpty(status) && Enum.TryParse<TransactionStatus>(status, out var ts))
            query = query.Where(t => t.TransactionStatus == ts);
        return View(await query.OrderByDescending(t => t.TransactionCreated).ToListAsync());
    }

    public async Task<IActionResult> Detail(int id)
    {
        var item = await _repo.Query().Include(t => t.Orders).ThenInclude(o => o.Product).FirstOrDefaultAsync(t => t.TransactionId == id);
        if (item == null) return NotFound();
        return View(item);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateStatus(int id, string status)
    {
        var item = await _repo.GetByIdAsync(id);
        if (item == null) return NotFound();
        if (Enum.TryParse<TransactionStatus>(status, out var ts))
            item.TransactionStatus = ts;
        await _repo.UpdateAsync(item);
        return RedirectToAction(nameof(Index));
    }
}
