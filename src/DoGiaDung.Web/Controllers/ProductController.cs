using DoGiaDung.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DoGiaDung.Web.Controllers;

public class ProductController : Controller
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService) => _productService = productService;

    public async Task<IActionResult> Index(string? search)
    {
        var result = await _productService.GetAllAsync(search);
        return View(result.Data);
    }

    public async Task<IActionResult> Detail(int id)
    {
        var result = await _productService.GetByIdAsync(id);
        if (!result.IsSuccess) return NotFound();
        return View(result.Data);
    }
}
