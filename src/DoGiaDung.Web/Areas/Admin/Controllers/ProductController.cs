using DoGiaDung.Application.DTOs;
using DoGiaDung.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DoGiaDung.Web.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize]
public class ProductController : Controller
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService) => _productService = productService;

    public async Task<IActionResult> Index(string? search)
    {
        var result = await _productService.GetAllAsync(search);
        return View(result.Data);
    }

    public IActionResult Create() => View();

    [HttpPost]
    public async Task<IActionResult> Create(ProductCreateDto dto)
    {
        var result = await _productService.CreateAsync(dto);
        if (!result.IsSuccess) return View(dto);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var result = await _productService.GetByIdAsync(id);
        if (!result.IsSuccess) return NotFound();
        return View(result.Data);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, ProductCreateDto dto)
    {
        var result = await _productService.UpdateAsync(id, dto);
        if (!result.IsSuccess) return View(dto);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        await _productService.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
