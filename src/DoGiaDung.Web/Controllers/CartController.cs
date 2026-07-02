using DoGiaDung.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DoGiaDung.Web.Controllers;

public class CartController : Controller
{
    private readonly ICartService _cart;
    private readonly IProductService _products;

    public CartController(ICartService cart, IProductService products)
    {
        _cart = cart;
        _products = products;
    }

    public IActionResult Index()
    {
        return View(_cart.GetCart());
    }

    public async Task<IActionResult> Add(int id)
    {
        var product = await _products.GetByIdAsync(id);
        if (!product.IsSuccess) return NotFound();

        var p = product.Data!;
        _cart.AddItem(p.ProductId, p.ProductName, p.Price, p.PriceWithVat, p.ImageLink);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Update(int productId, int quantity)
    {
        _cart.UpdateQuantity(productId, quantity);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Remove(int productId)
    {
        _cart.RemoveItem(productId);
        return RedirectToAction("Index");
    }
}
